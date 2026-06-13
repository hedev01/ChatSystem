using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Common;

namespace ChatSystem.Application.Features.Users.Register
{
    public interface IRegisterUseCase
    {
        Task<Result<RegisterResponse>> Register(RegisterRequest request);
    }
}
