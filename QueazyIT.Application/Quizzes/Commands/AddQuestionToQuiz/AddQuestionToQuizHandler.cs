using QueazyIT.Application.Common.Commands;
using QueazyIT.Application.Common.Exceptions;
using QueazyIT.Core.Quizzes.Repositories;

namespace QueazyIT.Application.Quizzes.Commands.AddQuestionToQuiz;

internal sealed class AddQuestionToQuizHandler : ICommandHandler<AddQuestionToQuizCommand, AddQuestionToQuizResponse>
{
    private readonly IQuizRepository _quizRepository;

    public AddQuestionToQuizHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task<AddQuestionToQuizResponse> HandleAsync(AddQuestionToQuizCommand command, CancellationToken cancellationToken = default)
    {
        var quiz = await _quizRepository.GetQuizAsync(command.QuizId, cancellationToken);

        if (quiz is null)
            throw new NotFoundException(command.QuizId, "Quiz");
        
        var question = quiz.AddQuestion(command.Content);
        await _quizRepository.UpdateAsync(quiz, cancellationToken);
        return new AddQuestionToQuizResponse(question.Id);
    }
}