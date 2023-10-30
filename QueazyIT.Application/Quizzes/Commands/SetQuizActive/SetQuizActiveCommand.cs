using QueazyIT.Application.Common.Commands;

namespace QueazyIT.Application.Quizzes.Commands.SetQuizActive;

internal record SetQuizActiveCommand(bool IsActive) : ICommand
{
    internal Guid QuizId { get; }
}