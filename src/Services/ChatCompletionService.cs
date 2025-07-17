using System.ClientModel;
using Azure.AI.OpenAI;
using kvandijk.Common.Exceptions;
using kvandijk.Common.Interfaces;
using Microsoft.Extensions.Logging;
using OpenAI.Chat;

namespace kvandijk.Common.Services;

/// <summary>
/// A service that interacts with an Azure OpenAI Chat API to provide chat message completions based on user input.
/// </summary>
public class ChatCompletionService : IChatCompletionService
{
    private readonly ChatClient _chatClient;

    public ChatCompletionService(ILogger<ChatCompletionService> logger)
    {
        var apiUrl = Environment.GetEnvironmentVariable("AZURE_OPENAI_URL") ?? throw new InvalidOperationException("AZURE_OPENAI_URL not set in environment variables");
        var apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_KEY") ?? throw new InvalidOperationException("AZURE_OPENAI_KEY not set in environment variables");
        var deploymentName = Environment.GetEnvironmentVariable("AZURE_DEPLOYMENT_NAME") ?? throw new InvalidOperationException("AZURE_DEPLOYMENT_NAME not set in environment variables");

        var azureClient = new AzureOpenAIClient(new Uri(apiUrl), new ApiKeyCredential(apiKey));
        _chatClient = azureClient.GetChatClient(deploymentName);
    }

    /// <summary>
    /// Retrieves a chat completion response based on a prompt and instruction provided, using the chat client.
    /// </summary>
    /// <param name="prompt">The prompt message to be shown to the user.</param>
    /// <param name="instruction">The instruction message to be passed to the system for processing.</param>
    /// <returns>The chat completion response as a string.</returns>
    public async Task<string> GetChatCompletionAsync(string prompt, string instruction)
    {
        var systemMessage = new SystemChatMessage(instruction);
        var userMessage = new UserChatMessage(prompt);
        var messages = new List<ChatMessage> { systemMessage, userMessage };

        ChatCompletion completion;
        try
        {
            completion = await _chatClient.CompleteChatAsync(messages);
        }
        catch (Exception ex)
        {
            throw new ChatCompletionException("Failed to get chat completion.", ex);
        }

        var response = completion.Content.FirstOrDefault()?.Text ?? string.Empty;

        return response;
    }
}
