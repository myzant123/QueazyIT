using QueazyIT.Infrastructure.EF;

namespace QueazyIT.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDataAccess();
        return services;
    }
}