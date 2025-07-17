namespace kvandijk.Common.Interfaces;

public interface IChatCompletionService
{
    Task<string> GetChatCompletionAsync(string prompt, string instruction);
}
