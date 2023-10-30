namespace QueazyIT.Core.Quizzes.ValueObjects.Title.Exceptions;

internal class InvalidTitleException : Exception
{
    public string InvalidTitle { get; }
    
    public InvalidTitleException(string invalidTitle) : base($"Title: '{invalidTitle}' is invalid.")
    {
        InvalidTitle = invalidTitle;
    }
}