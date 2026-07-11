using ChatSystem.Api.SignalR;
using ChatSystem.Application;
using ChatSystem.Application.Common.Security;
using ChatSystem.Application.Features.Users.Login;
using ChatSystem.Application.Features.Users.Register;
using ChatSystem.Application.Interfaces;
using ChatSystem.Application.Interfaces.Messaging;
using ChatSystem.Application.Service;
using ChatSystem.Application.UseCase;
using ChatSystem.Domain.Interfaces;
using ChatSystem.Infrastructure.Messaging;
using ChatSystem.Infrastructure.Options;
using ChatSystem.Infrastructure.Repositories;
using ChatSystem.Infrastructure.Security;
using ChatSystem.Infrastructure.Services;
using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.SignalR;
using LoginRequest = ChatSystem.Application.Features.Users.Login.LoginRequest;
using RegisterRequest = ChatSystem.Application.Features.Users.Register.RegisterRequest;

namespace ChatSystem.Api.DI
{
    public class Dependencies
    {
        public static void Inject(IServiceCollection service , IConfiguration configuration)
        {
            service.Configure<RabbitMqOptions>(configuration.GetSection(RabbitMqOptions.SectionName));
            service.AddSingleton<IUserIdProvider, CustomUserIdProvider>()
                .AddScoped<IMessageRepository, MessageRepository>()
                .AddScoped<IChatService, ChatService>()
                .AddScoped<IPresenceService, PresenceService>()
                .AddScoped<IJwtTokenService, JwtTokenService>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddSingleton<IUserConnectionRepository, InMemoryConnectionRepository>()
                .AddSingleton<RabbitMqConnection>()
                .AddScoped<IPasswordHasher, PasswordHasher>()
                .AddApplication()
                .AddScoped<IValidator<RegisterRequest>, RegisterValidator>()
                .AddScoped<IValidator<LoginRequest>, LoginValidator>()
                .AddScoped<IMessagePublisher, RabbitMqPublisher>();

        }
    }
}
