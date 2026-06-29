using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Application.Interfaces
{
    public interface IPresenceService
    {
        Task<bool> UserConnected(string userId, string connectionId);

        Task<bool> UserDisconnected(string userId, string connectionId);

        Task<IReadOnlyList<string>> GetOnlineUsers();
    }
}
