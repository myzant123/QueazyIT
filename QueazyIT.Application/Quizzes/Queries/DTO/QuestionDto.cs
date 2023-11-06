namespace QueazyIT.Application.Quizzes.Queries.DTO;

internal record QuestionDto(Guid Id,
    Guid QuizId,
    string Content,
    int OrderNo,
    bool IsSingleChoice,
    List<AnswerDto> Answers);