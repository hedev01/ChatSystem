using ChatSystem.Api.SignalR;
using ChatSystem.Application;
using ChatSystem.Application.Common.Security;
using ChatSystem.Application.Features.Users.Register;
using ChatSystem.Application.Interfaces;
using ChatSystem.Application.UseCase;
using ChatSystem.Domain.Interfaces;
using ChatSystem.Infrastructure.Repositories;
using ChatSystem.Infrastructure.Security;
using ChatSystem.Infrastructure.Services;
using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.SignalR;
using RegisterRequest = ChatSystem.Application.Features.Users.Register.RegisterRequest;

namespace ChatSystem.Api.DI
{
    public class Dependencies
    {
        public static void Inject(IServiceCollection service)
        {
            service.AddSingleton<IUserIdProvider, CustomUserIdProvider>()
                .AddScoped<IMessageRepository, MessageRepository>()
                .AddScoped<IChatService, ChatService>()
                .AddScoped<IJwtTokenService, JwtTokenService>()
                .AddScoped<IUserRepository , UserRepository>()
                .AddScoped<IPasswordHasher , PasswordHasher>()
                .AddApplication()
                .AddScoped<IValidator<RegisterRequest>, RegisterValidator>();

        }
    }
}
