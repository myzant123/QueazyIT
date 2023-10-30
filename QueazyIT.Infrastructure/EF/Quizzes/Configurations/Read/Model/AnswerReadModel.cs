namespace QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read.Model;

internal sealed class AnswerReadModel
{
    public Guid Id { get; init; }
    public Guid QuestionId { get; init; }
    public string Content { get; init; }
    public int OrderNo { get; init; }
    public bool IsRightAnswer { get; init; }
}