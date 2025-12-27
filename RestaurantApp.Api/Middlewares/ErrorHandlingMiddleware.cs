using System.Text.Json;
using RestaurantApp.Domain.Exceptions;

namespace RestaurantApp.Api.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context); // Run Middlewares
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync(ex.Message);
            logger.LogWarning(ex.Message);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "* Unhandled exception occurred while processing request *");
            
            context.Response.StatusCode = 500; // Internal Server Error
            await context.Response.WriteAsync("Some thing went wrong !!");
        }
    }
}