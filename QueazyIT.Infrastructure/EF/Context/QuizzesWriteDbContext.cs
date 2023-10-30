using Microsoft.EntityFrameworkCore;
using QueazyIT.Core.Quizzes.Entities;
using QueazyIT.Infrastructure.EF.Quizzes.Configurations.Write;

namespace QueazyIT.Infrastructure.EF.Context;

internal class QuizzesWriteDbContext : DbContext
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    
    public QuizzesWriteDbContext(DbContextOptions<QuizzesWriteDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("quizzes");

        modelBuilder.ApplyConfiguration(new QuizWriteConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionWriteConfiguration());
        modelBuilder.ApplyConfiguration(new AnswerWriteConfiguration());
    }
}