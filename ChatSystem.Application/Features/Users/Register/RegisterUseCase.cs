using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Common;
using ChatSystem.Application.Common.Security;
using ChatSystem.Application.Interfaces;
using ChatSystem.Application.Interfaces.Messaging;
using ChatSystem.Contracts.Events;
using ChatSystem.Domain.Entities;
using ChatSystem.Domain.Interfaces;
using IJwtTokenService = ChatSystem.Application.Interfaces.IJwtTokenService;

namespace ChatSystem.Application.Features.Users.Register
{
    internal sealed class RegisterUseCase : IRegisterUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMessagePublisher _messagePublisher;

        public RegisterUseCase(IUserRepository userRepository, IJwtTokenService jwtTokenService , IPasswordHasher passwordHasher , IMessagePublisher messagePublisher)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
            _passwordHasher = passwordHasher;
            _messagePublisher = messagePublisher;
        }
        public async Task<Result<RegisterResponse>> Register(RegisterRequest request)
        {
            bool emailExists = await _userRepository.EmailExists(request.email);

            if (emailExists)
                return Result<RegisterResponse>.Failure("Email Has Exists");


            var hashPassword = _passwordHasher.Hash(request.password);


            var user = User.Register(
                request.userName,
                request.email,
                hashPassword,
                request.firstName,
                request.lastName);



            await _userRepository.Register(user);



            await _messagePublisher.PublishAsync(
                new UserRegisteredEvent(
                    user.UserId,
                    user.FirstName + "" + user.LastName,
                    user.Email
                ));



            var accessToken =
                _jwtTokenService.GenerateToken(
                    user.Username,
                    user.UserId);



            return Result<RegisterResponse>.Success(
                new RegisterResponse(
                    user.UserId,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    accessToken));
        }
    }
}
