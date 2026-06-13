using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }

        public Guid UserId { get; private set; }


        public string Username { get; private set; }
        public string Email { get;  private set; }


        public string PasswordHash { get; private set; }


        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }


        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastLoginAt { get; private set; }

        private User()
        {

        }



        public static User Register(string username, string email, string password, string firstname, string lastname)
        {
            return new User
            {
                UserId = Guid.NewGuid(),
                Username = username,
                Email = email,
                PasswordHash = password,
                FirstName = firstname,
                LastName = lastname,
                IsActive = true,
                CreatedAt = DateTime.Now,
                LastLoginAt = null
        };
        }
    }
}
