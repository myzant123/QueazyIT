using QueazyIT.Core.Quizzes.Exceptions;
using QueazyIT.Core.Quizzes.Types.QuestionId;
using QueazyIT.Core.Quizzes.Types.QuizId;
using QueazyIT.Core.Quizzes.ValueObjects.Description;
using QueazyIT.Core.Quizzes.ValueObjects.Password;
using QueazyIT.Core.Quizzes.ValueObjects.Title;
using Timer = QueazyIT.Core.Quizzes.ValueObjects.Timer.Timer;

namespace QueazyIT.Core.Quizzes.Entities;

internal sealed class Quiz
{
    private const ushort MaxQuestionsNum = 50;
    public QuizId Id { get; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Timer Timer { get; private set; }
    public Password Password { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsPreviousQuestion { get; private set; }

    private readonly HashSet<Question> _questions = new();
    public IEnumerable<Question> Questions => _questions;

    public Quiz() { }

    private Quiz(QuizId id, Title title, Description description, Timer timer, Password password, bool isActive, bool isPreviousQuestion)
    {
        Id = id;
        Title = title;
        Description = description;
        Timer = timer;
        Password = password;
        IsActive = isActive;
        IsPreviousQuestion = isPreviousQuestion;
    }

    public static Quiz Create(Title title, Description description, Timer timer, Password password, bool isActive, bool isPreviousQuestion)
    {
        return new Quiz(QuizId.Create(), title, description, timer, password, isActive, isPreviousQuestion);
    }
    
    public void ChangeInformation(Title title, Description description, Timer timer, Password password)
    {
        Title = title;
        Description = description;
        Timer = timer;
        Password = password;
    }

    public void SetActive(bool isActive)
    {
        IsActive = isActive;
    }

    public void SetPreviousQuestion(bool isPreviousQuestion)
    {
        IsPreviousQuestion = isPreviousQuestion;
    }

    private Question GetQuestionById(QuestionId questionId)
    {
        var question = _questions.FirstOrDefault(q => q.Id == questionId);
        if (question is null)
            throw new QuestionNotFoundException(questionId);

        return question;
    }
    
    public void AddQuestion(string content)
    {
        if (_questions.Count >= MaxQuestionsNum)
            throw new QuestionsCountExceededException();

        var question = Question.Create(Id, content);
        
        var orderNo = GetNextQuestionOrderNo();
        question.SetQuestionOrderNo(orderNo);
        _questions.Add(question);
    }
    
    private int GetNextQuestionOrderNo()
    {
        var orderNo = _questions.Count;
        return orderNo += 1;
    }
    
    public void RemoveQuestion(QuestionId questionId)
    {
        var question = GetQuestionById(questionId);
        _questions.Remove(question);
        
        var questionsToMove = _questions.Where(x => x.OrderNo > question.OrderNo).ToList();
        foreach (var questionToMove in questionsToMove) questionToMove.DecrementOrderNo();
    }
}