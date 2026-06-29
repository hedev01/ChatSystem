using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Application.Interfaces
{
    public interface IUserConnectionRepository
    {
        Task<bool> AddConnection(string userId, string connectionId);
        Task<bool> RemoveConnection(string userId, string connectionId);
        Task<IReadOnlyList<string>> GetOnlineUsers();
        Task<bool> IsOnline(string userId);
    }
}
