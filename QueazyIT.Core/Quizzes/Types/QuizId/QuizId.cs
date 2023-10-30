namespace QueazyIT.Core.Quizzes.Types.QuizId;

internal class QuizId : TypeId
{
    public QuizId(Guid value) : base(value)
    {
    }

    public static QuizId Create() => new(Guid.NewGuid());

    public static implicit operator QuizId(Guid id) => new(id);
    public static implicit operator Guid(QuizId id) => id.Value;
}