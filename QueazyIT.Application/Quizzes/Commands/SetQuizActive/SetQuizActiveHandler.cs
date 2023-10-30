using QueazyIT.Application.Common.Commands;
using QueazyIT.Application.Common.Exceptions;
using QueazyIT.Core.Quizzes.Repositories;

namespace QueazyIT.Application.Quizzes.Commands.SetQuizActive;

internal sealed class SetQuizActiveHandler : ICommandHandler<SetQuizActiveCommand>
{
    private readonly IQuizRepository _quizRepository;

    public SetQuizActiveHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task HandleAsync(SetQuizActiveCommand command, CancellationToken cancellationToken = default)
    {
        var quiz = await _quizRepository.GetQuizAsync(command.QuizId, cancellationToken);

        if (quiz is null)
            throw new NotFoundException(command.QuizId, "Quiz");
        
        quiz.SetActive(command.IsActive);
        await _quizRepository.UpdateAsync(quiz, cancellationToken);
    }
}