namespace QueazyIT.Core.Quizzes.ValueObjects.Password.Exceptions;

internal class InvalidPasswordException : Exception
{
    public string InvalidPassword { get; }

    public InvalidPasswordException(string invalidPassword) 
        : base($"Invalid password: '{invalidPassword}' does not meet the required criteria.")
    {
        InvalidPassword = invalidPassword;
    }
}