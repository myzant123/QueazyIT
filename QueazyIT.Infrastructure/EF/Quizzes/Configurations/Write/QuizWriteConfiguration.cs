using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueazyIT.Core.Quizzes.Entities;
using QueazyIT.Core.Quizzes.Types.QuizId;
using QueazyIT.Core.Quizzes.ValueObjects.Description;
using QueazyIT.Core.Quizzes.ValueObjects.Password;
using QueazyIT.Core.Quizzes.ValueObjects.Title;
using Timer = QueazyIT.Core.Quizzes.ValueObjects.Timer.Timer;

namespace QueazyIT.Infrastructure.EF.Quizzes.Configurations.Write;

internal class QuizWriteConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.ToTable("Quizzes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new QuizId(x));
        
        builder.Property<Title>("Title")
            .HasConversion(x => x.Value, x => new Title(x));
        
        builder.Property<Description>("Description")
            .HasConversion(x => x.Value, x => new Description(x));
        
        builder.Property<Timer>("Timer")
            .HasConversion(x => x.Value, x => new Timer(x));
        
        builder.Property<Password>("Password")
            .HasConversion(x => x.Value, x => new Password(x));
        
        builder.Property<bool>("IsActive").IsRequired();
        builder.Property<bool>("IsPreviousQuestion").IsRequired();
    }
}