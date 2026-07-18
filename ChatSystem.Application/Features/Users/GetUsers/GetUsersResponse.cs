using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Application.Features.Users.GetUsers
{
    public record GetUsersResponse(Guid userId,
        string firstName,
        string lastName,
        string email,
        string avatarUrl);
}
