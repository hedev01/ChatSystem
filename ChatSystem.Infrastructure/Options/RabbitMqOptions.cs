using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Infrastructure.Options
{
    public class RabbitMqOptions
    {
        public const string SectionName = "RabbitMQ";

        public string HostName { get; init; } = default!;

        public int Port { get; init; }

        public string UserName { get; init; } = default!;

        public string Password { get; init; } = default!;

        public string ExchangeName { get; init; } = default!;
    }
}
