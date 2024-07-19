using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ
{
    internal static class Receiver
    {
        public static List<string> Receive(this RabbitMQConfig rabbitMQConfig, ILogger<object> logger)
        {
            var factory = new ConnectionFactory()
            {
                HostName = rabbitMQConfig.HostName,
                Port = rabbitMQConfig.Port
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            try
            {
                // Declare the exchange
                channel.ExchangeDeclare(exchange: rabbitMQConfig.ExchangeName, type: ExchangeType.Direct, durable: false);

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

                var consumer = new EventingBasicConsumer(channel);
                
                List<string> messages = new List<string>();

                // AutoResetEvent to signal when message processing is done
                using AutoResetEvent messageReceivedEvent = new AutoResetEvent(false);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    messages.Add(message);

                    // Acknowledge the message
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                    // Signal that a message was received and processed
                    messageReceivedEvent.Set();
                };

                channel.BasicConsume(queue: rabbitMQConfig.QueueName,
                                     autoAck: false,
                                     consumer: consumer);

                // Wait for messages to be received
                // You can adjust the timeout value as needed
                messageReceivedEvent.WaitOne(10000); // Wait for up to 10 seconds

                return messages;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.LogError(ex.Message, ex);
            }
            finally
            {
                channel.Close();
                connection.Dispose();
            }

            return new List<string>();
        }
    }
}
