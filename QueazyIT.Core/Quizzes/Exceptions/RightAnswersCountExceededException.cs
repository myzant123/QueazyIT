namespace QueazyIT.Core.Quizzes.Exceptions;

public class RightAnswersCountExceededException : Exception
{
    public RightAnswersCountExceededException() : base("Too many right answers in the single choice question.")
    {
    }
}