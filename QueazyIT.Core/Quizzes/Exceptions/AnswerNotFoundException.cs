namespace QueazyIT.Core.Quizzes.Exceptions;

internal class AnswerNotFoundException : Exception
{
    private Guid Id { get; }
    public AnswerNotFoundException(Guid id) : base($"Answer with id: '{id}' not found.")
    {
        Id = id;
    }
}