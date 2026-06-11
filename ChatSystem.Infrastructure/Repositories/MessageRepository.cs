using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Domain.Entities;
using ChatSystem.Domain.Interfaces;
using ChatSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatSystem.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Message message)
        {
            await _context.Message.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>> GetConversationAsync(string user1, string user2)
        {
            return await _context.Message
                .Where(m =>
                    (m.SenderId == user1 && m.ReceiverId == user2) ||
                    (m.SenderId == user2 && m.ReceiverId == user1))
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }
    }
}
