using Application;
using Application.Users;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
        {
            services.AddWebDependencies();
            services.AddApplication();

            return services;
        }

        private static IServiceCollection AddWebDependencies(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();

            return services;
        }
    }
}
