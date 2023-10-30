using QueazyIT.Application.Common.Commands;
using QueazyIT.Application.Common.Exceptions;
using QueazyIT.Core.Quizzes.Repositories;

namespace QueazyIT.Application.Quizzes.Commands.AddAnswerToQuestion;

internal sealed class AddAnswerToQuestionHandler : ICommandHandler<AddAnswerToQuestionCommand>
{
    private readonly IQuizRepository _quizRepository;

    public AddAnswerToQuestionHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task HandleAsync(AddAnswerToQuestionCommand command, CancellationToken cancellationToken = default)
    {
        var question = await _quizRepository.GetQuestionAsync(command.QuestionId, cancellationToken);

        if (question is null)
            throw new NotFoundException(command.QuestionId, "Question");
        
        question.AddAnswer(command.Content, command.IsRightAnswer);
        await _quizRepository.CommitAsync(cancellationToken);
    }
}