using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Interfaces;

namespace ChatSystem.Infrastructure.Repositories
{
    public class InMemoryConnectionRepository : IUserConnectionRepository
    {
        private readonly ConcurrentDictionary<string, HashSet<string>> _connections = new();

        public Task<bool> AddConnection(string userId, string connectionId)
        {
            var set = _connections.GetOrAdd(userId, _ => new HashSet<string>());

            lock (set)
            {
                var firstConnection = set.Count == 0;
                set.Add(connectionId);
                return Task.FromResult(firstConnection);
            }
        }

        public Task<bool> RemoveConnection(string userId, string connectionId)
        {
            if (!_connections.TryGetValue(userId, out var set))
                return Task.FromResult(false);

            lock (set)
            {
                set.Remove(connectionId);

                if (set.Count == 0)
                {
                    _connections.TryRemove(userId, out _);
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
        }

        public Task<IReadOnlyList<string>> GetOnlineUsers()
        {
            return Task.FromResult((IReadOnlyList<string>)_connections.Keys.ToList());
        }

        public Task<bool> IsOnline(string userId)
        {
            return Task.FromResult(_connections.ContainsKey(userId));
        }
    }
}
