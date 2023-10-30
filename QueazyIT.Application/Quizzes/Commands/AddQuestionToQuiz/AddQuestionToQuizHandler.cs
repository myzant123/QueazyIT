using QueazyIT.Application.Common.Commands;
using QueazyIT.Application.Common.Exceptions;
using QueazyIT.Core.Quizzes.Repositories;

namespace QueazyIT.Application.Quizzes.Commands.AddQuestionToQuiz;

internal sealed class AddQuestionToQuizHandler : ICommandHandler<AddQuestionToQuizCommand>
{
    private readonly IQuizRepository _quizRepository;

    public AddQuestionToQuizHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task HandleAsync(AddQuestionToQuizCommand command, CancellationToken cancellationToken = default)
    {
        var quiz = await _quizRepository.GetQuizAsync(command.QuizId, cancellationToken);

        if (quiz is null)
            throw new NotFoundException(command.QuizId, "Quiz");
        
        quiz.AddQuestion(command.Content);
        await _quizRepository.UpdateAsync(quiz, cancellationToken);
    }
}