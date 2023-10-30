using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read.Model;

namespace QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read;

internal class QuestionReadConfiguration : IEntityTypeConfiguration<QuestionReadModel>
{
    public void Configure(EntityTypeBuilder<QuestionReadModel> builder)
    {
        builder.ToTable("Questions");
    }
}