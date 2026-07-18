using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ChatSystem.Application.Events;
using ChatSystem.Application.Interfaces.Messaging;
using ChatSystem.Contracts.Events;
using RabbitMQ.Client;

namespace ChatSystem.Infrastructure.Messaging
{
    public sealed class RabbitMqPublisher : IMessagePublisher
    {
        private readonly RabbitMqConnection _connection;


        public RabbitMqPublisher(
            RabbitMqConnection connection)
        {
            _connection = connection;
        }

        public async Task PublishAsync<T>(
            T message,
            CancellationToken cancellationToken = default)
            where T : IntegrationEvent
        {
            Console.WriteLine(
                $"Publishing Event: {typeof(T).Name}"
            );

            
            var channel = await _connection.CreateChannelAsync();


            await channel.ExchangeDeclareAsync(
                exchange: "chat.exchange",
                type: ExchangeType.Topic,
                durable: true);



            var body = JsonSerializer.SerializeToUtf8Bytes(message);



            await channel.BasicPublishAsync(
                exchange: "chat.exchange",
                routingKey: typeof(T).Name,
                body: body);



            await channel.DisposeAsync();
        }
    }
}
