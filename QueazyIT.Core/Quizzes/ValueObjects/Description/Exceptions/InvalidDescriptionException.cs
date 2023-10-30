namespace QueazyIT.Core.Quizzes.ValueObjects.Description.Exceptions;

internal class InvalidDescriptionException : Exception
{
    public string InvalidDescription { get; }

    public InvalidDescriptionException(string invalidDescription) : base($"Description: '{invalidDescription}' is invalid.")
    {
        InvalidDescription = invalidDescription;
    }
}