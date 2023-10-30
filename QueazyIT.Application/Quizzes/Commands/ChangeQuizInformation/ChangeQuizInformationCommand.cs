using QueazyIT.Application.Common.Commands;

namespace QueazyIT.Application.Quizzes.Commands.ChangeQuizInformation;

internal record ChangeQuizInformationCommand
    (string Title, string Description, TimeSpan Timer, string Password) : ICommand
{
    internal Guid QuizId { get; }
}