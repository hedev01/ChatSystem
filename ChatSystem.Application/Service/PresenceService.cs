using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Interfaces;

namespace ChatSystem.Application.Service
{
    public class PresenceService : IPresenceService
    {
        private readonly IUserConnectionRepository _userConnectionRepository;

        public PresenceService(IUserConnectionRepository userConnectionRepository)
        {
            _userConnectionRepository = userConnectionRepository;
        }
        public Task<bool> UserConnected(string userId, string connectionId)
        {
           return _userConnectionRepository.AddConnection(userId, connectionId);
        }

        public Task<bool> UserDisconnected(string userId, string connectionId)
        {
            return _userConnectionRepository.RemoveConnection(userId, connectionId);
        }

        public  Task<IReadOnlyList<string>> GetOnlineUsers()
        {
            return _userConnectionRepository.GetOnlineUsers();
        }
    }
}
