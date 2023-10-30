namespace QueazyIT.Core.Quizzes.Types.AnswerId;

internal class AnswerId : TypeId
{
    public AnswerId(Guid value) : base(value)
    {
    }

    public static AnswerId Create() => new(Guid.NewGuid());

    public static implicit operator AnswerId(Guid id) => new(id);
    public static implicit operator Guid(AnswerId id) => id.Value;
}