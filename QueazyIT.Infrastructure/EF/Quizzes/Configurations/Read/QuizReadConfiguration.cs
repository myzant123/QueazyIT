using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read.Model;

namespace QueazyIT.Infrastructure.EF.Quizzes.Configurations.Read;

internal class QuizReadConfiguration : IEntityTypeConfiguration<QuizReadModel>
{
    public void Configure(EntityTypeBuilder<QuizReadModel> builder)
    {
        builder.ToTable("Quizzes");
    }
}