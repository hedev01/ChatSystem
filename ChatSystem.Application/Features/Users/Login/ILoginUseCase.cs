using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Common;

namespace ChatSystem.Application.Features.Users.Login
{
    public interface ILoginUseCase
    {
        Task<Result<LoginResponse>> Login(LoginRequest request);
    }
}
