using QueazyIT.Application.Common.Commands;
using QueazyIT.Application.Common.Exceptions;
using QueazyIT.Core.Quizzes.Repositories;

namespace QueazyIT.Application.Quizzes.Commands.ChangeQuizInformation;

internal sealed class ChangeQuizInformationHandler : ICommandHandler<ChangeQuizInformationCommand>
{
    private readonly IQuizRepository _quizRepository;

    public ChangeQuizInformationHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task HandleAsync(ChangeQuizInformationCommand command, CancellationToken cancellationToken = default)
    {
        var quiz = await _quizRepository.GetQuizAsync(command.QuizId, cancellationToken);

        if (quiz is null)
            throw new NotFoundException(command.QuizId, "Quiz");
        
        quiz.ChangeInformation(command.Title, command.Description, command.Timer, command.Password);
        await _quizRepository.UpdateAsync(quiz, cancellationToken);
    }
}