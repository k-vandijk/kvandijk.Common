using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace kvandijk.Common.Diagnostics;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimingMiddleware> _logger;

    private readonly int _warningThresholdMilliseconds = 500;

    public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Logs the time taken to process each HTTP request.
    /// If the request takes longer than the defined threshold, it logs a warning; otherwise, it logs informational.
    /// </summary>
    /// <param name="context">The current HttpContext.</param>
    /// <returns>A Task to be awaited.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        // If the endpoint has the SkipRequestTimingAttribute, skip timing
        var endpoint = context.GetEndpoint();
        if (endpoint?.Metadata?.GetMetadata<SkipRequestTimingAttribute>() != null)
        {
            await _next(context);
            return;
        }

        var sw = Stopwatch.StartNew();
        try
        {
            await _next(context);
        }
        finally
        {
            sw.Stop();
            var elapsed = sw.ElapsedMilliseconds;

            var method = context.Request.Method;
            var path = context.Request.Path;
            var statusCode = context.Response?.StatusCode ?? 0;

            if (elapsed > _warningThresholdMilliseconds)
            {
                _logger.LogWarning("Slow request: {Method} {Path} took {Elapsed} ms (status {StatusCode})", method, path, elapsed, statusCode);
            }
            else
            {
                _logger.LogInformation("{Method} {Path} completed in {Elapsed} ms (status {StatusCode})", method, path, elapsed, statusCode);
            }
        }
    }
}