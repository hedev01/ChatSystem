using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Events;

namespace ChatSystem.Application.Interfaces.Messaging
{
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(
            T message,
            CancellationToken cancellationToken = default)
            where T : IntegrationEvent;
    }
}
