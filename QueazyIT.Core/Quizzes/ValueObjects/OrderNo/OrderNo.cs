using QueazyIT.Core.Quizzes.ValueObjects.OrderNo.Exceptions;

namespace QueazyIT.Core.Quizzes.ValueObjects.OrderNo;

internal class OrderNo : ValueObject
{
    public int Value { get; }
    
    private const int MinValue = 0;
    private const int MaxValue = 100;

    internal OrderNo(int value)
    {
        if (value is < MinValue or > MaxValue)
            throw new InvalidOrderNoRangeException(value);
        
        Value = value;
    }
    
    public static implicit operator OrderNo(int value) => new(value);
    public static implicit operator int(OrderNo value) => value.Value;
}