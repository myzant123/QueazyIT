namespace QueazyIT.Core.Quizzes.ValueObjects.Content.Exceptions;

internal class InvalidContentException : Exception
{
    public string InvalidContent { get; }

    public InvalidContentException(string invalidContent) : base($"Content: '{invalidContent}' is invalid.")
    {
        InvalidContent = invalidContent;
    }
}