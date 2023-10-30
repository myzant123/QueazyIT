using QueazyIT.Application.Common.Commands;

namespace QueazyIT.Application.Quizzes.Commands.AddQuestionToQuiz;

internal record AddQuestionToQuizCommand(string Content) : ICommand
{
    internal Guid QuizId { get; }
}