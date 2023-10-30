using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QueazyIT.Core.Quizzes.Repositories;
using QueazyIT.Infrastructure.EF.Context;
using QueazyIT.Infrastructure.EF.Quizzes.Repositories;

namespace QueazyIT.Infrastructure.EF;

internal static class DataAccessLayer
{
    private const string OptionsSectionName = "postgres";

    internal static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddPostgres<QuizzesReadDbContext>()
            .AddPostgres<QuizzesWriteDbContext>();

        services
            .AddScoped<IQuizRepository, QuizRepository>();
        
        return services;
    }

    private static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
    {
        var options = services.GetOptions<PostgresOptions>(OptionsSectionName);

        services.AddDbContext<T>(x => x.UseNpgsql(options.ConnectionString));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        return services;
    }

    private static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.GetOptions<T>(sectionName);
    }

    private static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }
}