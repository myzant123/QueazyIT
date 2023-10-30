using QueazyIT.Application.Common.Commands;
using QueazyIT.Application.Common.Exceptions;
using QueazyIT.Core.Quizzes.Repositories;

namespace QueazyIT.Application.Quizzes.Commands.RemoveQuestionFromQuiz;

internal sealed class RemoveQuestionFromQuizHandler : ICommandHandler<RemoveQuestionFromQuizCommand>
{
    private readonly IQuizRepository _quizRepository;

    public RemoveQuestionFromQuizHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task HandleAsync(RemoveQuestionFromQuizCommand command, CancellationToken cancellationToken = default)
    {
        var quiz = await _quizRepository.GetQuizAsync(command.QuizId, cancellationToken);

        if (quiz is null)
            throw new NotFoundException(command.QuizId, "Quiz");
        
        quiz.RemoveQuestion(command.QuestionId);
        await _quizRepository.UpdateAsync(quiz, cancellationToken);
    }
}