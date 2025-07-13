namespace kvandijk.Common.Middleware;

using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

/// <summary>
/// Middleware for logging incoming HTTP requests and their responses.
/// </summary>
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestLoggingMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="logger">The logger to use for logging requests.</param>
    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Invokes the middleware to log incoming HTTP requests and their responses.
    /// </summary>
    /// <param name="context">The HTTP context for the current request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Invoke(HttpContext context)
    {
        var request = context.Request;

        var requestId = Guid.NewGuid().ToString()[..8];
        context.Items["RequestId"] = requestId;

        _logger.LogInformation("[{RequestId}] {Method} {Path} incoming.", requestId, request.Method, request.Path);

        var stopwatch = Stopwatch.StartNew();
        await _next(context);
        stopwatch.Stop();

        _logger.LogInformation("[{RequestId}] Finished with code {StatusCode} in {ElapsedMilliseconds}ms.", requestId, context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
    }
}