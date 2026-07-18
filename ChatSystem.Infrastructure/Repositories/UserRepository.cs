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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Register(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> Login(string email)
        {
            var result = await _context.Users.SingleOrDefaultAsync(user => user.Email == email);
            return result;
        }

        public async Task<bool> EmailExists(string email)
        {
            var result = await _context.Users.AnyAsync(user => user.Email == email);
            return result;
        }

        public async Task<List<User?>> GetUsers(Guid userId)
        {
            var result = await _context.Users.Where(user => user.UserId != userId).ToListAsync();
            return result!;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUser(Guid userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserId == userId);
            return user;
        }
    }
}
