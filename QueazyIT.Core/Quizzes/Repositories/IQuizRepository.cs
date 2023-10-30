using QueazyIT.Core.Quizzes.Entities;
using QueazyIT.Core.Quizzes.Types.QuestionId;
using QueazyIT.Core.Quizzes.Types.QuizId;

namespace QueazyIT.Core.Quizzes.Repositories;

internal interface IQuizRepository
{
    Task<Quiz> GetQuizAsync(QuizId quizId, CancellationToken cancellationToken);
    Task<Question> GetQuestionAsync(QuestionId questionId, CancellationToken cancellationToken);
    Task AddAsync(Quiz quiz, CancellationToken cancellationToken);
    Task UpdateAsync(Quiz quiz, CancellationToken cancellationToken);
    Task DeleteAsync(Quiz quiz, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
}