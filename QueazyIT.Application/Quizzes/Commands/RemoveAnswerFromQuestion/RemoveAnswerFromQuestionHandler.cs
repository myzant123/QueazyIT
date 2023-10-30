using QueazyIT.Application.Common.Commands;
using QueazyIT.Application.Common.Exceptions;
using QueazyIT.Core.Quizzes.Repositories;

namespace QueazyIT.Application.Quizzes.Commands.RemoveAnswerFromQuestion;

internal sealed class RemoveAnswerFromQuestionHandler : ICommandHandler<RemoveAnswerFromQuestionCommand>
{
    private readonly IQuizRepository _quizRepository;

    public RemoveAnswerFromQuestionHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task HandleAsync(RemoveAnswerFromQuestionCommand command, CancellationToken cancellationToken = default)
    {
        var question = await _quizRepository.GetQuestionAsync(command.QuestionId, cancellationToken);

        if (question is null)
            throw new NotFoundException(command.QuestionId, "Question");
        
        question.RemoveAnswer(command.AnswerId);
        await _quizRepository.CommitAsync(cancellationToken);
    }
}