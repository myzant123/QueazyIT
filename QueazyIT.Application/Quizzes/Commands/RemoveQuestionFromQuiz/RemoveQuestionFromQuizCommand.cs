using QueazyIT.Application.Common.Commands;

namespace QueazyIT.Application.Quizzes.Commands.RemoveQuestionFromQuiz;

internal record RemoveQuestionFromQuizCommand(Guid QuizId, Guid QuestionId) : ICommand;