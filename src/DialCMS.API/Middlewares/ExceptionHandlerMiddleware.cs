using System.Net;
using System.Text.Json;

namespace DialCMS.API.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/problem+json";

        // Mapear exceções para status HTTP
        var statusCode = exception switch
        {
            ArgumentException => (int)HttpStatusCode.BadRequest,
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        response.StatusCode = statusCode;

        var problemDetails = new
        {
            type = statusCode == (int)HttpStatusCode.InternalServerError
                ? "https://httpstatuses.com/500"
                : "https://httpstatuses.com/" + statusCode,
            title = exception.GetType().Name,
            status = statusCode,
            detail = exception.Message,
            instance = context.Request.Path
        };

        return response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }
}