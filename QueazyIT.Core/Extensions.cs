using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("QueazyIT.Application")]
[assembly: InternalsVisibleTo("QueazyIT.Infrastructure")]

namespace QueazyIT.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}