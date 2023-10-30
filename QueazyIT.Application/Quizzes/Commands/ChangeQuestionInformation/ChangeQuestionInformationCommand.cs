using QueazyIT.Application.Common.Commands;

namespace QueazyIT.Application.Quizzes.Commands.ChangeQuestionInformation;

internal record ChangeQuestionInformationCommand(string Content, bool IsSingleChoice) : ICommand
{
    internal Guid QuestionId { get; }
}