namespace QueazyIT.Core.Quizzes.Types.QuestionId;

internal class QuestionId : TypeId
{
    public QuestionId(Guid value) : base(value)
    {
    }

    public static QuestionId Create() => new(Guid.NewGuid());

    public static implicit operator QuestionId(Guid id) => new(id);
    public static implicit operator Guid(QuestionId id) => id.Value;
}