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
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>> GetConversationAsync(Guid user1, Guid user2)
        {
            return await _context.Messages
                .Where(m =>
                    (m.SenderId == user1 && m.ReceiverId == user2) ||
                    (m.SenderId == user2 && m.ReceiverId == user1))
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        public async Task MarkConversationAsRead(Guid senderId, Guid receiverId)
        {
            var messages = await _context.Messages
                .Where(x =>
                    x.SenderId == senderId &&
                    x.ReceiverId == receiverId &&
                    !x.IsRead)
                .ToListAsync();

            foreach (var message in messages)
            {
                message.IsRead = true;
            }

            await _context.SaveChangesAsync();
        }
    }
}
