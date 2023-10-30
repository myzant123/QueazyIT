using QueazyIT.Core.Quizzes.ValueObjects.Description.Exceptions;
using QueazyIT.Core.Quizzes.ValueObjects.Title.Exceptions;

namespace QueazyIT.Core.Quizzes.ValueObjects.Description;

internal class Description : ValueObject
{
    public string Value { get; }
    private const int MaxLength = 200;

    internal Description(string value)
    {
        if (value.Length > MaxLength)
            throw new InvalidDescriptionException(value);
        
        Value = value;
    }
    
    public static implicit operator Description(string value) => value is null ? null : new Description(value);
    public static implicit operator string(Description value) => value?.Value;
}