using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ
{
    internal static class Sender
    {
        public static bool Send<T>(this RabbitMQConfig rabbitMQConfig, T messageObject, ILogger<object> logger)
        {
            try
            {
                // Serialize the object to a JSON string
                string message = JsonConvert.SerializeObject(messageObject);

                var factory = new ConnectionFactory() { HostName = rabbitMQConfig.HostName, Port = rabbitMQConfig.Port };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                // Declare the exchange
                channel.ExchangeDeclare(exchange: rabbitMQConfig.ExchangeName, type: ExchangeType.Direct);

                // Declare the queue
                channel.QueueDeclare(queue: rabbitMQConfig.QueueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // Bind the queue to the exchange with the routing key
                channel.QueueBind(queue: rabbitMQConfig.QueueName,
                                  exchange: rabbitMQConfig.ExchangeName,
                                  routingKey: rabbitMQConfig.RoutingKey);

                // Set the message properties to make it persistent
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                // Publish the message to the exchange with the routing key
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: rabbitMQConfig.ExchangeName,
                                     routingKey: rabbitMQConfig.RoutingKey,
                                     basicProperties: properties, // Set the message properties
                                     body: body);

                Console.WriteLine($" [x] Sent: {message}");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.LogError(ex.Message, ex);
            }

            return false;
        }
    }
}
