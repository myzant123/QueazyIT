using QueazyIT.Core.Quizzes.Exceptions;
using QueazyIT.Core.Quizzes.Types.AnswerId;
using QueazyIT.Core.Quizzes.Types.QuestionId;
using QueazyIT.Core.Quizzes.Types.QuizId;
using QueazyIT.Core.Quizzes.ValueObjects.Content;
using QueazyIT.Core.Quizzes.ValueObjects.OrderNo;

namespace QueazyIT.Core.Quizzes.Entities;

internal sealed class Question
{
    private const ushort MaxAnswersNum = 10;
    public QuestionId Id { get; }
    public QuizId QuizId { get; }
    public Content Content { get; private set; }
    public OrderNo OrderNo { get; private set; }
    public bool IsSingleChoice { get; private set; }
    
    private readonly HashSet<Answer> _answers = new();
    public IEnumerable<Answer> Answers  => _answers;

    public Question() { }

    private Question(QuestionId id, QuizId quizId, Content content)
    {
        Id = id;
        QuizId = quizId;
        Content = content;
    }

    public static Question Create(QuizId quizId, Content content)
    {
        return new Question(QuestionId.Create(), quizId, content);
    }

    public void ChangeQuestionInformation(Content content, bool isSingleChoice)
    {
        Content = content;
        IsSingleChoice = isSingleChoice;
    }

    public void SetQuestionOrderNo(OrderNo orderNo)
    {
        OrderNo = orderNo;
    }

    private Answer GetAnswerById(AnswerId answerId)
    {
        var answer = _answers.FirstOrDefault(a => a.Id == answerId);
        if (answer is null)
            throw new AnswerNotFoundException(answerId);

        return answer;
    }
    
    public void AddAnswer(string content, bool isRightAnswer)
    {
        if (_answers.Count >= MaxAnswersNum)
            throw new AnswersCountExceededException();

        if (IsSingleChoice && _answers.Any(a => a.IsRightAnswer))
            throw new RightAnswersCountExceededException();
        
        var answer = Answer.Create(Id, content, isRightAnswer);
        
        var orderNo = GetNextAnswerOrderNo();
        answer.SetAnswerOrderNo(orderNo);
        _answers.Add(answer);
    }

    public void RemoveAnswer(AnswerId answerId)
    {
        var answer = GetAnswerById(answerId);
        _answers.Remove(answer);

        var answersToMove = _answers.Where(a => a.OrderNo > answer.OrderNo).ToList();
        foreach (var answerToMove in answersToMove) answerToMove.DecrementOrderNo();
    }

    public int GetAllRightAnswers()
    {
        return _answers.Count(a => a.IsRightAnswer);
    }
    
    private int GetNextAnswerOrderNo()
    {
        var orderNo = _answers.Count;
        return orderNo += 1;
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