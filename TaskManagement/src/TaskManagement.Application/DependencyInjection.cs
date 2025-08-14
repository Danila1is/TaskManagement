using Application.Users;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions;
using TaskManagement.Application.Users.Login;
using TaskManagement.Application.Users.Registration;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddScoped<ICommandHandler<string, LoginCommand> ,LoginHandler>();
            services.AddScoped<ICommandHandler<Guid, RegistrationCommand> ,RegistrationHandler>();

            return services;
        }
    }
}
