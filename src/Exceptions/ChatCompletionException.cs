namespace kvandijk.Common.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an error occurs during chat message completion.
/// </summary>
public class ChatCompletionException : Exception
{
    public ChatCompletionException()
    {
    }

    public ChatCompletionException(string message)
        : base(message)
    {
    }

    public ChatCompletionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
