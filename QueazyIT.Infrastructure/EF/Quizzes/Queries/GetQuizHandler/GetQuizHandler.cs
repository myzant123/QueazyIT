using Microsoft.EntityFrameworkCore;
using QueazyIT.Application.Common.Queries;
using QueazyIT.Application.Quizzes.Queries.GetQuiz;
using QueazyIT.Application.Quizzes.Queries.GetQuiz.DTO;
using QueazyIT.Infrastructure.EF.Context;

namespace QueazyIT.Infrastructure.EF.Quizzes.Queries.GetQuizHandler;

internal sealed class GetQuizHandler : IQueryHandler<GetQuiz, QuizDetailsDto?>
{
    private readonly QuizzesReadDbContext _readDbContext;

    public GetQuizHandler(QuizzesReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }
    
    public async Task<QuizDetailsDto?> HandleAsync(GetQuiz query, CancellationToken cancellationToken = default)
    {
        var quiz = await _readDbContext.Quizzes.AsNoTracking()
            .Include(q => q.Questions)
            .ThenInclude(a => a.Answers)
            .SingleOrDefaultAsync(q => q.Id == query.QuizId, cancellationToken);

        return quiz?.AsDetailsDto();
    }
}