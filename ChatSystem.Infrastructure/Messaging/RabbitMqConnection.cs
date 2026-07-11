using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Infrastructure.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace ChatSystem.Infrastructure.Messaging
{
    public sealed class RabbitMqConnection : IAsyncDisposable
    {
        private readonly Task<IConnection> _connectionTask;

        public RabbitMqConnection(IOptions<RabbitMqOptions> options)
        {
            var factory = new ConnectionFactory
            {
                HostName = options.Value.HostName,
                Port = options.Value.Port,
                UserName = options.Value.UserName,
                Password = options.Value.Password
            };

            _connectionTask = factory.CreateConnectionAsync();
        }


        public async Task<IChannel> CreateChannelAsync()
        {
            var connection = await _connectionTask;

            return await connection.CreateChannelAsync();
        }



        public async ValueTask DisposeAsync()
        {
            var connection = await _connectionTask;

            await connection.DisposeAsync();
        }
    }
}
