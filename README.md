# clean-architecture-rabbitmq-training

# **Overview**
Small demo for RabbitMQ integration with two Apis:
* Banking.Api will publish a message in TransferCreatedEvent queue with the transfer information.
* Transfer.Api will consume that message and store a record in SQL Server.

# **Technology Stack**
* NetCore 7.0 for Apis using Clean architecture
* Docker for SQL Server and RabbitMQ
* MediatR pattern and IoC. 