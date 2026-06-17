using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Application.Features.Users.Login
{
    public record LoginRequest(string email, string password);
}
