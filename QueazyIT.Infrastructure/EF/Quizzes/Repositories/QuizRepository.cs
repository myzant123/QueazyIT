using Microsoft.EntityFrameworkCore;
using QueazyIT.Core.Quizzes.Entities;
using QueazyIT.Core.Quizzes.Repositories;
using QueazyIT.Core.Quizzes.Types.QuestionId;
using QueazyIT.Core.Quizzes.Types.QuizId;
using QueazyIT.Infrastructure.EF.Context;

namespace QueazyIT.Infrastructure.EF.Quizzes.Repositories;

internal class QuizRepository : IQuizRepository
{
    private readonly QuizzesWriteDbContext _context;
    private readonly DbSet<Quiz> _quizzes;
    private readonly DbSet<Question> _questions;

    public Task<Quiz> GetQuizAsync(QuizId quizId, CancellationToken cancellationToken)
        => _quizzes
            .Where(q => q.Id == quizId)
            .Include(u => u.Questions)
            .ThenInclude(a => a.Answers)
            .SingleOrDefaultAsync(cancellationToken);

    public Task<Question> GetQuestionAsync(QuestionId questionId, CancellationToken cancellationToken)
        => _questions
            .Where(q => q.Id == questionId)
            .Include(a => a.Answers)
            .SingleOrDefaultAsync(cancellationToken);

    public async Task AddAsync(Quiz quiz, CancellationToken cancellationToken)
    {
        await _quizzes.AddAsync(quiz, cancellationToken);
        await CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(Quiz quiz, CancellationToken cancellationToken)
    {
        _quizzes.Update(quiz);
        await CommitAsync(cancellationToken);
    }

    public async Task DeleteAsync(Quiz quiz, CancellationToken cancellationToken)
    {
        _quizzes.Remove(quiz);
        await CommitAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}