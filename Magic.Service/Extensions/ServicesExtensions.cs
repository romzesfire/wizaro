using Microsoft.Extensions.DependencyInjection;

namespace Magic.Service.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        return services;
    }
}