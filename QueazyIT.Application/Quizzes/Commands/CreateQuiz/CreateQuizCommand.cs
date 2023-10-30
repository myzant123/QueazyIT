using QueazyIT.Application.Common.Commands;

namespace QueazyIT.Application.Quizzes.Commands.CreateQuiz;

internal record CreateQuizCommand(string Title, string Description, TimeSpan Timer, string Password, bool IsActive, bool IsPreviousQuestion) : ICommand<CreateQuizResponse>;