using QueazyIT.Application.Common.Queries;
using QueazyIT.Application.Quizzes.Queries.GetQuiz.DTO;

namespace QueazyIT.Application.Quizzes.Queries.GetQuiz;

internal record GetQuiz(Guid QuizId) : IQuery<QuizDetailsDto?>;