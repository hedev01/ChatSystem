using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Domain.Entities;

namespace ChatSystem.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task Register(User entity);
        Task<User?> Login(string email);
        Task<bool> EmailExists(string email);
        Task<List<User?>> GetUsers(Guid userId);
    }
}
