using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.DTO;
using ChatSystem.Application.Interfaces;
using ChatSystem.Domain.Entities;
using ChatSystem.Domain.Interfaces;

namespace ChatSystem.Application.UseCase
{
    public class ChatService : IChatService
    {
        private readonly IMessageRepository _repo;
        public ChatService(IMessageRepository repo)
        {
            _repo = repo;
        }

        public async Task SendMessage(MessageDto dto)
        {
            var message = new Message
            {
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
                Content = dto.Content
            };

            await _repo.AddAsync(message);
        }

        public async Task MarkConversationAsRead(Guid senderId, Guid receiverId)
        {
            await _repo.MarkConversationAsRead(senderId, receiverId);
        }
    }
}
