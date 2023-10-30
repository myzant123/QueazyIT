using QueazyIT.Application.Common.Commands;

namespace QueazyIT.Application.Quizzes.Commands.RemoveAnswerFromQuestion;

internal record RemoveAnswerFromQuestionCommand(Guid QuestionId, Guid AnswerId) : ICommand;