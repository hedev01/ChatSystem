using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.DTO;

namespace ChatSystem.Application.Interfaces
{
    public interface IChatService
    {
        Task SendMessage(MessageDto dto);
        Task MarkConversationAsRead(Guid senderId, Guid receiverId);
    }
}
