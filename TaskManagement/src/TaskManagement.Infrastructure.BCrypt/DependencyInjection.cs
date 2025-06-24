using Application.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Infrastructure.Hasher;

namespace TaskManagement.Infrastructure.PostgreSQL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBCrypt(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
