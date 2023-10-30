namespace QueazyIT.Core.Quizzes.Exceptions;

internal class AnswersCountExceededException : Exception
{
    public AnswersCountExceededException() : base("Too many answers in the question.")
    {
    }
}