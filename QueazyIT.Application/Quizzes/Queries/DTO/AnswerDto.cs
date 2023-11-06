namespace QueazyIT.Application.Quizzes.Queries.DTO;

internal record AnswerDto(
    Guid Id,
    Guid QuestionId,
    string Content,
    int OrderNo,
    bool IsRightAnswer);