using QueazyIT.Core.Quizzes.Types.AnswerId;
using QueazyIT.Core.Quizzes.Types.QuestionId;
using QueazyIT.Core.Quizzes.ValueObjects.Content;
using QueazyIT.Core.Quizzes.ValueObjects.OrderNo;

namespace QueazyIT.Core.Quizzes.Entities;

internal sealed class Answer
{
    public AnswerId Id { get; }
    public QuestionId QuestionId { get; }
    public Content Content { get; private set; }
    public OrderNo OrderNo { get; private set; }
    public bool IsRightAnswer { get; private set; }

    public Answer() { }

    private Answer(AnswerId id, QuestionId questionId, Content content, bool isRightAnswer)
    {
        Id = id;
        QuestionId = questionId;
        Content = content;
        IsRightAnswer = isRightAnswer;
    }

    public static Answer Create(QuestionId questionId, Content content, bool isRightAnswer)
    {
        return new Answer(AnswerId.Create(), questionId, content, isRightAnswer);
    }
    
    public void ChangeContent(Content content)
    {
        Content = content;
    }
    
    public void SetAnswerOrderNo(OrderNo orderNo)
    {
        OrderNo = orderNo;
    }

    public void SetRightAnswer(bool isRightAnswer)
    {
        IsRightAnswer = isRightAnswer;
    }
    
    public void IncrementOrderNo()
    {
        OrderNo += 1;
    }
    
    public void DecrementOrderNo()
    {
        OrderNo -= 1;
    }
}