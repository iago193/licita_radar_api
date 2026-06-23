using System.Net;
using System.Text.Json;
using LicitaRadarApi.Exceptions_app;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (AppException ex)
        {
            await HandleException(context, ex.StatusCode, ex.Message);
        }
        catch (Exception)
        {
            await HandleException(
                context,
                (int)HttpStatusCode.InternalServerError,
                "Erro interno no servidor"
            );
        }
    }

    private static async Task HandleException(HttpContext context, int statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new
        {
            message,
            statusCode,
            traceId = context.TraceIdentifier
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}