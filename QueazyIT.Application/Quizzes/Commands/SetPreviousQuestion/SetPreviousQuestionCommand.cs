using QueazyIT.Application.Common.Commands;

namespace QueazyIT.Application.Quizzes.Commands.SetPreviousQuestion;

internal record SetPreviousQuestionCommand(bool IsPreviousQuestion) : ICommand
{
    internal Guid QuizId { get; }
}