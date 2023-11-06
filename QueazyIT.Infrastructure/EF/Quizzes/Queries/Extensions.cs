using QueazyIT.Application.Quizzes.Queries.DTO;
using QueazyIT.Application.Quizzes.Queries.GetQuiz.DTO;
using QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read.Model;

namespace QueazyIT.Infrastructure.EF.Quizzes.Queries;

internal static class Extensions
{
    public static QuizDetailsDto AsDetailsDto(this QuizReadModel quizReadModel) => new()
    {
        Id = quizReadModel.Id,
        Title = quizReadModel.Title,
        Description = quizReadModel.Description,
        Timer = quizReadModel.Timer,
        Password = quizReadModel.Password,
        IsActive = quizReadModel.IsActive,
        IsPreviousQuestion = quizReadModel.IsPreviousQuestion,
        Questions = quizReadModel.Questions?
            .Select(q => new QuestionDto(q.Id, q.QuizId, q.Content, q.OrderNo, q.IsSingleChoice, q.Answers?
                .Select(a => new AnswerDto(a.Id, a.QuestionId, a.Content, a.OrderNo, a.IsRightAnswer)).ToList())).ToList()
    };
}