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
        Task<List<Message>> GetConversationAsync(string user1, string user2);
    }
}
