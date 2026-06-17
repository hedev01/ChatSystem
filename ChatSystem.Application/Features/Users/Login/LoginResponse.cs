using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Application.Features.Users.Login
{
    public record LoginResponse(Guid userId,
        string firstName,
        string lastName,
        string email,
        string accessToken);
}
