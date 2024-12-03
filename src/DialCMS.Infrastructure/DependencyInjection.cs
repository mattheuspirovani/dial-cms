using DialCMS.Domain.Repositories;
using DialCMS.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DialCMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register Repositories
        services.AddSingleton<IContentRepository, InMemoryContentRepository>();
        services.AddSingleton<ITemplateRepository, InMemoryTemplateRepository>();
        return services;
    }
}