namespace kvandijk.Common.Extensions;

using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;

/// <summary>
/// Extension methods for configuring Serilog in a WebApplicationBuilder.
/// </summary>
public static class SerilogExtensions
{
    /// <summary>
    /// Configures Serilog for the application.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder of the application.</param>
    public static void ConfigureSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}