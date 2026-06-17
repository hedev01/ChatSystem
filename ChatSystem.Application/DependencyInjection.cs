using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Application.Features.Users.Login;
using ChatSystem.Application.Features.Users.Register;
using Microsoft.Extensions.DependencyInjection;

namespace ChatSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IRegisterUseCase, RegisterUseCase>()
                .AddScoped<ILoginUseCase , LoginUseCase>();
            return service;
        }
    }
}
