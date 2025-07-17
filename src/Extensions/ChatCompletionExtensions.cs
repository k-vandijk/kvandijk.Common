using kvandijk.Common.Interfaces;
using kvandijk.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace kvandijk.Common.Extensions;

public static class ChatCompletionExtensions
{
    public static IServiceCollection AddChatCompletions(this IServiceCollection services)
    {
        services.AddScoped<IChatCompletionService, ChatCompletionService>();

        return services;
    }
}