using JetBrains.Annotations;

namespace QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read.Model;

internal sealed class QuizReadModel
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description  { get; init; }
    public TimeSpan Timer { get; init; }
    public string Password { get; init; }
    public bool IsActive { get; init; }
    public bool IsPreviousQuestion { get; init; }
    [CanBeNull] public IEnumerable<QuestionReadModel> Questions { get; init; }
}