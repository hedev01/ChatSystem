using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Application.Events
{
    public abstract record IntegrationEvent
    {
        public Guid EventId { get; init; } = Guid.NewGuid();

        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
