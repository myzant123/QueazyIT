namespace QueazyIT.Core.Quizzes.ValueObjects.OrderNo.Exceptions;

internal class InvalidOrderNoRangeException : Exception
{
    private int InvalidOrderNo { get; }
    
    public InvalidOrderNoRangeException(int invalidOrderNo) : base($"OrderNo: {invalidOrderNo} is out of range.")
    {
        InvalidOrderNo = invalidOrderNo;
    }
}