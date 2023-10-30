using QueazyIT.Core.Quizzes.ValueObjects.Content.Exceptions;

namespace QueazyIT.Core.Quizzes.ValueObjects.Content;

internal class Content : ValueObject
{
    public string Value { get; }
    private const int MaxLength = 250;

    internal Content(string value)
    {
        if (value.Length > MaxLength)
            throw new InvalidContentException(value);
        
        Value = value;
    }
    
    public static implicit operator Content(string value) => value is null ? null : new Content(value);
    public static implicit operator string(Content value) => value?.Value;
}