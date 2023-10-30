using QueazyIT.Application.Common.Commands;
using QueazyIT.Application.Common.Exceptions;
using QueazyIT.Core.Quizzes.Repositories;

namespace QueazyIT.Application.Quizzes.Commands.ChangeQuestionInformation;

internal sealed class ChangeQuestionInformationHandler : ICommandHandler<ChangeQuestionInformationCommand>
{
    private readonly IQuizRepository _quizRepository;

    public ChangeQuestionInformationHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task HandleAsync(ChangeQuestionInformationCommand command, CancellationToken cancellationToken = default)
    {
        var question = await _quizRepository.GetQuestionAsync(command.QuestionId, cancellationToken);

        if (question is null)
            throw new NotFoundException(command.QuestionId, "Question");
        
        question.ChangeQuestionInformation(command.Content, command.IsSingleChoice);
        await _quizRepository.CommitAsync(cancellationToken);
    }
}