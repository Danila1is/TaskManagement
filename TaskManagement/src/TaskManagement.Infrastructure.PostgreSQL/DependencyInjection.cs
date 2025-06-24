using Application.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Infrastructure.PostgreSQL.Repositories;

namespace TaskManagement.Infrastructure.PostgreSQL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostgresql(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<PostgresqlDbContext>(
                options =>
                {
                    options.UseNpgsql(connectionString);
                });

            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}
