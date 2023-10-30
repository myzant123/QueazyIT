using QueazyIT.Application.Common.Commands;

namespace QueazyIT.Application.Quizzes.Commands.AddAnswerToQuestion;

internal record AddAnswerToQuestionCommand(string Content, bool IsRightAnswer) : ICommand
{
    internal Guid QuestionId { get; }
}