namespace QueazyIT.Core.Quizzes.Exceptions;

internal class QuestionNotFoundException : Exception
{
    private Guid Id { get; }
    public QuestionNotFoundException(Guid id) : base($"Question with id: '{id}' not found.")
    {
        Id = id;
    }
}