using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Domain.Entities;

namespace ChatSystem.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task AddAsync(Message message);
        Task<List<Message>> GetConversationAsync(Guid user1, Guid user2);
        Task MarkConversationAsRead(Guid senderId, Guid receiverId);
    }
}
