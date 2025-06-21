using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace kvandijk.Common.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var request = context.Request;

        var requestId = Guid.NewGuid().ToString()[..8];
        context.Items["RequestId"] = requestId;

        _logger.LogInformation("[{RequestId}] {Method} {Path} incoming.", 
            requestId, request.Method, request.Path);

        var stopwatch = Stopwatch.StartNew();
        await _next(context);
        stopwatch.Stop();

        _logger.LogInformation("[{RequestId}] Finished with code {StatusCode} in {ElapsedMilliseconds}ms.",
            requestId, context.Response.StatusCode, stopwatch.ElapsedMilliseconds);

    }
}