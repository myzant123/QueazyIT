using FluentAssertions;
using QueazyIT.Core.Quizzes.Entities;
using QueazyIT.Core.Quizzes.Exceptions;
using QueazyIT.Core.Quizzes.Types.QuestionId;
using QueazyIT.Core.Quizzes.ValueObjects.Description;
using QueazyIT.Core.Quizzes.ValueObjects.Password;
using QueazyIT.Core.Quizzes.ValueObjects.Password.Exceptions;
using QueazyIT.Core.Quizzes.ValueObjects.Title;
using Timer = QueazyIT.Core.Quizzes.ValueObjects.Timer.Timer;

namespace QueazyIT.Tests.Unit.Entities;

public class QuizTest
{
    private readonly Quiz _quiz;
    
    public QuizTest()
    {
        _quiz = Quiz.Create(
            "QuizTitle", 
            "QuizDescription",
            Timer.FromHours(2),
            "QuizPassword!23",
            true,
            false);
    }

    [Fact]
    public void ChangeInformation_ValidParameters_ChangesInformation()
    {
        // Arrange
        var newTitle = new Title("NewTitle");
        var newDescription = new Description("NewDescription");
        var timer = _quiz.Timer;
        var newPassword = new Password("NewPassword!23");

        // Act
        _quiz.ChangeInformation(newTitle, newDescription, timer ,newPassword);

        // Assert
        _quiz.Title.Should().Be(newTitle);
        _quiz.Description.Should().Be(newDescription);
        _quiz.Timer.Should().Be(timer);
        _quiz.Password.Should().Be(newPassword);
    }
    
    [Fact]
    public void ChangeInformation_InvalidPassword_ThrowsInvalidPasswordException()
    {
        // Arrange
        var newTitle = new Title("NewTitle");
        var newDescription = new Description("NewDescription");
        var timer = _quiz.Timer;
        var newPassword = "NewPassword";

        // Act
        var action = new Action(() => _quiz.ChangeInformation(newTitle, newDescription, timer, newPassword)); 

        // Assert
        action.Should().Throw<InvalidPasswordException>();
    }
    
    [Fact]
    public void GetQuestionById_ValidQuestionId_ReturnsQuestion()
    {
        // Arrange
        var question = _quiz.AddQuestion("QuestionContent");
        
        // Act
        var result = _quiz.GetQuestionById(question.Id);

        // Assert
        result.Should().Be(question);
    }
    
    [Fact]
    public void GetQuestionById_QuestionNotFound_ThrowsQuestionNotFoundException()
    {
        // Arrange
        var questionId = QuestionId.Create();
        
        // Act
        var action = new Action(() => _quiz.GetQuestionById(questionId));

        // Assert
        action.Should().Throw<QuestionNotFoundException>();
    }
    
    [Fact]
    public void AddQuestion_ValidParameters_AddsQuestionWithCorrectOrderNo()
    {
        // Arrange
        var content = "QuestionContent2";
        
        // Act
        _quiz.AddQuestion("QuestionContent");
        var question = _quiz.AddQuestion(content);

        // Assert
        _quiz.Questions.Should().Contain(question);
        question.QuizId.Should().Be(_quiz.Id);
        question.Content.Value.Should().Be(content);
        question.OrderNo.Value.Should().Be(2);
    }
    
    [Fact]
    public void AddQuestion_MaximumQuestionsExceeded_ThrowsQuestionsCountExceededException()
    {
        // Arrange
        for (var i = 0; i < Quiz.GetMaxQuestionsNum(); i++)
            _quiz.AddQuestion($"QuestionContent{i}");
        
        // Act
        var action = new Action(() => _quiz.AddQuestion("QuestionContentX"));

        // Assert
        action.Should().Throw<QuestionsCountExceededException>();
    }

    [Fact]
    public void RemoveQuestion_ValidQuestion_RemovesQuestionAndUpdatesOtherOrderNumbers()
    {
        // Arrange
        var question1 = _quiz.AddQuestion("QuestionContent1");
        var question2 = _quiz.AddQuestion("QuestionContent2");
        var question3 = _quiz.AddQuestion("QuestionContent3");
        var question4 = _quiz.AddQuestion("QuestionContent4");

        // Act
        _quiz.RemoveQuestion(question2.Id);
        
        // Assert
        _quiz.Questions.Should().NotContain(question2);
        question1.OrderNo.Value.Should().Be(1);
        question3.OrderNo.Value.Should().Be(2);
        question4.OrderNo.Value.Should().Be(3);
    }
}