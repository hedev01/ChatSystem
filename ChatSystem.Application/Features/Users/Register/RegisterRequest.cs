using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Application.Features.Users.Register
{
    public record RegisterRequest(string userName, string password, string email, string firstName, string lastName);
}
