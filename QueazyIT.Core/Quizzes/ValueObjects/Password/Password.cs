using System.Text.RegularExpressions;
using QueazyIT.Core.Quizzes.ValueObjects.Password.Exceptions;

namespace QueazyIT.Core.Quizzes.ValueObjects.Password;

internal partial class Password : ValueObject
{
    public string Value { get; }
    private static readonly Regex PasswordRegex = MyRegex();

    internal Password(string value)
    {
        if (!IsValid(value))
            throw new InvalidPasswordException(value);

        Value = value;
    }

    public static implicit operator Password(string value) => new(value);
    public static implicit operator string(Password password) => password?.Value;

    private static bool IsValid(string password)
    {
        return !string.IsNullOrEmpty(password) && PasswordRegex.IsMatch(password);
    }

    public override string ToString() => Value;
    
    [GeneratedRegex("^(?=.*[A-Z])(?=.*\\d).{8,}$")] private static partial Regex MyRegex();
}