using QueazyIT.Application.Common.Commands;
using QueazyIT.Application.Common.Exceptions;
using QueazyIT.Core.Quizzes.Repositories;

namespace QueazyIT.Application.Quizzes.Commands.SetPreviousQuestion;

internal sealed class SetPreviousQuestionHandler : ICommandHandler<SetPreviousQuestionCommand>
{
    private readonly IQuizRepository _quizRepository;

    public SetPreviousQuestionHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task HandleAsync(SetPreviousQuestionCommand command, CancellationToken cancellationToken = default)
    {
        var quiz = await _quizRepository.GetQuizAsync(command.QuizId, cancellationToken);

        if (quiz is null)
            throw new NotFoundException(command.QuizId, "Quiz");
        
        quiz.SetPreviousQuestion(command.IsPreviousQuestion);
        await _quizRepository.UpdateAsync(quiz, cancellationToken);
    }
}