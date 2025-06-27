using Application;
using Application.Users;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Infrastructure.JWT;
using TaskManagement.Infrastructure.PostgreSQL;

namespace TaskManagement.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProgramDependencies(this IServiceCollection services,
            string? connectionString,
            IConfiguration configurationManager)
        {
            services.AddWebDependencies(configurationManager);
            services.AddApplication();
            services.AddPostgresql(connectionString);
            services.AddBCrypt();
            services.AddJWT();

            return services;
        }

        private static IServiceCollection AddWebDependencies(this IServiceCollection services, IConfiguration configurationManager)
        {
            services.AddControllers();
            services.AddOpenApi();
            services.Configure<JWTOptions>(configurationManager.GetSection(nameof(JWTOptions)));

            return services;
        }
    }
}
