using Microsoft.EntityFrameworkCore;
using QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read;
using QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read.Model;

namespace QueazyIT.Infrastructure.EF.Context;

internal class QuizzesReadDbContext : DbContext
{
    public DbSet<QuizReadModel> Quizzes { get; set; }
    public DbSet<QuestionReadModel> Questions { get; set; }
    public DbSet<AnswerReadModel> Answers { get; set; }
    
    public QuizzesReadDbContext(DbContextOptions<QuizzesWriteDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("quizzes");

        modelBuilder.ApplyConfiguration(new QuizReadConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionReadConfiguration());
        modelBuilder.ApplyConfiguration(new AnswerReadConfiguration());
    }
}