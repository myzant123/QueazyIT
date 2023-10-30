using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read.Model;

namespace QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read;

internal class AnswerReadConfiguration : IEntityTypeConfiguration<AnswerReadModel>
{
    public void Configure(EntityTypeBuilder<AnswerReadModel> builder)
    {
        builder.ToTable("Answers");
    }
}