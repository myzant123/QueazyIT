using QueazyIT.Application.Common.Commands;
using QueazyIT.Core.Quizzes.Entities;
using QueazyIT.Core.Quizzes.Repositories;

namespace QueazyIT.Application.Quizzes.Commands.CreateQuiz;

internal sealed class CreateQuizHandler : ICommandHandler<CreateQuizCommand, CreateQuizResponse>
{
    private readonly IQuizRepository _quizRepository;

    public CreateQuizHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task<CreateQuizResponse> HandleAsync(CreateQuizCommand command, CancellationToken cancellationToken = default)
    {
        var quiz = Quiz.Create(command.Title, command.Description, command.Timer, command.Password, command.IsActive,
            command.IsPreviousQuestion);

        await _quizRepository.AddAsync(quiz, cancellationToken);
        return new CreateQuizResponse(quiz.Id);
    }
}