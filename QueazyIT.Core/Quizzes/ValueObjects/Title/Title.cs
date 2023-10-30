using QueazyIT.Core.Quizzes.ValueObjects.Title.Exceptions;

namespace QueazyIT.Core.Quizzes.ValueObjects.Title;

internal class Title : ValueObject
{
    public string Value { get; }
    private const int MaxLength = 50;

    internal Title(string value)
    {
        if (value.Length > MaxLength)
            throw new InvalidTitleException(value);
        
        Value = value;
    }
    
    public static implicit operator Title(string value) => value is null ? null : new Title(value);
    public static implicit operator string(Title value) => value?.Value;
}