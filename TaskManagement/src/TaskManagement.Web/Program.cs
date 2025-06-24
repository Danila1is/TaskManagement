
using Microsoft.AspNetCore.Builder;
using TaskManagement.Infrastructure.PostgreSQL;

namespace TaskManagement.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString(nameof(PostgresqlDbContext))
                ?? throw new InvalidOperationException("Connection string or DefaultConnection not found");

            builder.Services.AddProgramDependencies(connectionString);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "TaskManagement"));
            }


            app.MapControllers();

            app.Run();
        }
    }
}
