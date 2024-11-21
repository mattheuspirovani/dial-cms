using System.Reflection;
using DialCMS.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DialCMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        // Register FluentValidation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddTransient<ContentValueUpdater>(); 

        return services;
    }
}