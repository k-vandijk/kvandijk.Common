﻿namespace kvandijk.Common.Exceptions;

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