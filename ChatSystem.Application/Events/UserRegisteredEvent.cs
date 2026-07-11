using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Events;

namespace ChatSystem.Contracts.Events
{
    public sealed record UserRegisteredEvent(Guid userId, string fullName, string email) : IntegrationEvent;
}
