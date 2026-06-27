using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Common;

namespace ChatSystem.Application.Features.Users.GetUsers
{
    public interface IGetUsersUseCase
    {
        Task<Result<List<GetUsersResponse>>> GetUsersAsync(Guid userId);
    }
}
