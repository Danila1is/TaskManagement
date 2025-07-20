using Shared;
using System.Text.Json;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Users.Fails;

namespace TaskManagement.Web.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            (int code, Error[]? errors) = exception switch
            {
                BadRequestException => (
                    StatusCodes.Status500InternalServerError, JsonSerializer.Deserialize<Error[]>(exception.Message)),

                NotFoundException => (
                    StatusCodes.Status404NotFound, JsonSerializer.Deserialize<Error[]>(exception.Message)),

                _ => (StatusCodes.Status500InternalServerError, [Error.Failure(null, "В первый раз вижу такую ошибку")])
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            await context.Response.WriteAsJsonAsync(errors);
        }
    }
}
