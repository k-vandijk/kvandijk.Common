using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace kvandijk.Common.Middleware;

public class ExceptionLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionLoggingMiddleware> _logger;

    public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var requestId = context.Items["RequestId"]?.ToString() ?? "N/A";

            _logger.LogError(ex, "[{RequestId}] An unhandled exception occured.", requestId);

            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("An unexpected error occurred.");

            _logger.LogInformation("[{RequestId}] Finished with code {StatusCode}.", requestId, context.Response.StatusCode);
        }
    }
}