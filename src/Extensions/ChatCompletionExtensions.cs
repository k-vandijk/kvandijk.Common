using kvandijk.Common.Interfaces;
using kvandijk.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace kvandijk.Common.Extensions;

/// <summary>
/// Provides extension methods for adding chat completion services to the IServiceCollection.
/// </summary>
public static class ChatCompletionExtensions
{
    /// <summary>
    /// Adds a chat completion service to the collection of services.
    /// </summary>
    /// <param name="services">The collection of services to which the chat completion service will be added.</param>
    /// <returns>The updated collection of services with the chat completion service added.</returns>
    public static IServiceCollection AddChatCompletions(this IServiceCollection services)
    {
        services.AddScoped<IChatCompletionService, ChatCompletionService>();

        return services;
    }
}
