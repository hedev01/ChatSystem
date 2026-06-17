using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Common;
using ChatSystem.Application.Common.Security;
using ChatSystem.Application.Interfaces;
using ChatSystem.Domain.Interfaces;

namespace ChatSystem.Application.Features.Users.Login
{
    internal sealed class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<Result<LoginResponse>> Login(LoginRequest request)
        {
            var user = await _userRepository.Login(request.email);
            if (user == null) return Result<LoginResponse>.Failure("User with this email was not found.");
            bool verifyPassword = _passwordHasher.Verify(request.password, user.PasswordHash);
            if (verifyPassword == false) return Result<LoginResponse>.Failure("User with this password was not found.");
            string token = _jwtTokenService.GenerateToken(user.Username, user.UserId);
            var response = new LoginResponse(user.UserId, user.FirstName, user.LastName, user.Email, token);
            return Result<LoginResponse>.Success(response);


        }
    }
}
