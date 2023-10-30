namespace QueazyIT.Core.Quizzes.Exceptions;

internal class QuestionsCountExceededException : Exception
{
    public QuestionsCountExceededException() : base("Too many questions in the quiz.")
    {
    }
}