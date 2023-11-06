using QueazyIT.Application.Quizzes.Queries.DTO;

namespace QueazyIT.Application.Quizzes.Queries.GetQuiz.DTO;

internal record struct QuizDetailsDto(
    Guid Id,
    string Title,
    string Description,
    TimeSpan Timer,
    string Password,
    bool IsActive,
    bool IsPreviousQuestion,
    List<QuestionDto> Questions);