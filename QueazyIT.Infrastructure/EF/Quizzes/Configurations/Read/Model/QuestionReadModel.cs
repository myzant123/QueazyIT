namespace QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read.Model;

internal sealed class QuestionReadModel
{
    public Guid Id { get; init; }
    public Guid QuizId { get; init; }
    public string Content { get; init; }
    public int OrderNo { get; init; }
    public bool IsSingleChoice { get; init; }
    public IEnumerable<AnswerReadModel> Answers { get; init; }
}