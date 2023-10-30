namespace QueazyIT.Core.Quizzes.Exceptions;

internal class QuestionOrderNoExceededException : Exception
{
    public QuestionOrderNoExceededException() : base("Question order number exceeded.")
    {
    }
}