using Microsoft.Extensions.DependencyInjection;

namespace Magic.Repository.Extensions;

public static class RepositoriesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }
}