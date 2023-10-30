using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueazyIT.Core.Quizzes.Entities;
using QueazyIT.Core.Quizzes.Types.AnswerId;
using QueazyIT.Core.Quizzes.Types.QuestionId;
using QueazyIT.Core.Quizzes.ValueObjects.Content;
using QueazyIT.Core.Quizzes.ValueObjects.OrderNo;

namespace QueazyIT.Infrastructure.EF.Quizzes.Configurations.Write;

internal class AnswerWriteConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answers");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AnswerId(x));
        
        builder.Property<QuestionId>("QuestionId")
            .IsRequired()
            .HasConversion(x => x.Value, x => new QuestionId(x));
        
        builder.Property<Content>("Content")
            .HasConversion(x => x.Value, x => new Content(x));
        
        builder.Property<OrderNo>("OrderNo")
            .HasConversion(x => x.Value, x => new OrderNo(x));

        builder.Property<bool>("IsRightAnswer").IsRequired();
    }
}