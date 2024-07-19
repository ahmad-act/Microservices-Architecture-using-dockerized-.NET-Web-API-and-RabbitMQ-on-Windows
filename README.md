# Microservices Architecture using dockerized .NET Web API and RabbitMQ on Windows

## Microcervice concept

### Apply loosely coupled relationship between Book Information and Book Reservation Services.

![Microcervice concept](https://raw.githubusercontent.com/awsaf-utm/public-resources/main/Microservice/Microservices%20Architecture%20Using%20.NET%20Web%20API%20and%20RabbitMQ%20on%20Windows.jpg?raw=true)

##### You have set up a microservices architecture using .NET Web API and RabbitMQ on Windows. This setup involves two services, Book Information and Book Reservation, communicating through RabbitMQ in a loosely coupled manner. Docker Desktop is used to manage the RabbitMQ container, and each service is run locally for development and testing purposes.

## Prerequisites

1. Docker Desktop: Download and install Docker Desktop from [Docker's official website](https://www.docker.com/products/docker-desktop/).

2. .NET SDK: Download and install the .NET SDK from [Microsoft's official website](https://dotnet.microsoft.com/download).

3. RabbitMQ Docker Image: You will need the RabbitMQ Docker image from Docker Hub.

## Step 1: Set up RabbitMQ using Docker

1. Pull the RabbitMQ Image:

    **Open a PowerShell and run the following command to pull the RabbitMQ Docker image:**

2. Run the RabbitMQ Container:

    **Run the RabbitMQ container with the management plugin enabled:**

    ```sh
    docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
    ```

    **This command runs RabbitMQ on port 5672 and the management plugin on port 15672.**

    **And keep the PowerShell window open as the Rabbit container will be closed after closing the PowerShell.**

3. Access RabbitMQ Management Console:

    **Open your browser and navigate to http://localhost:15672. Use the default credentials (username: guest, password: guest) to log in.**

## Step 2: Build and Run the Application

 1. Clone the project on your computer:
 
    **Using the TortoiseGit or GitBash or PowerShell:**
    
    ```sh
    git Clone 
    ```
 
 2. Build and Run the Book Information Services:
 
    **Execute the following commands using PowerShell:**
    
    ```sh
    cd "Microservices Architecture using dockerized .NET Web API and RabbitMQ on Windows\BookInformationService\BookInformationService"

    docker build --build-arg ENVIRONMENT=Development -t engzaman2020/book-information-api-v1-image:1 .

    docker run -it -p 3101:3101 --name book-information-api-v1-container engzaman2020/book-information-api-v1-image:1
    ```
 
    **Use the http://localhost:3101/swagger/index.html**
 
 3. Build and Run the Book Reservation Services:
 
    **Execute the following commands using PowerShell:**
    
    ```sh
    cd "Microservices Architecture using dockerized .NET Web API and RabbitMQ on Windows\BookReservationService\BookReservationService"

    docker build --build-arg ENVIRONMENT=Development -t engzaman2020/book-reservation-api-v1-image:1 .

    docker run -it -p 3102:3102 --name book-reservation-api-v1-container engzaman2020/book-reservation-api-v1-image:1
    ```
    
    **Use the http://localhost:3102/swagger/index.html**
