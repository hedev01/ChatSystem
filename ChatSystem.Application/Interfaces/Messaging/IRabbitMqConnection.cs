using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace ChatSystem.Application.Interfaces.Messaging
{
    public interface IRabbitMqConnection
    {
        IConnection Connection { get; }

        IChannel Channel { get; }
    }
}
