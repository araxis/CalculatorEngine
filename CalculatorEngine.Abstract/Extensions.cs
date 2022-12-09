using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorEngine.Abstract;

public static class Extensions
{

    public static IServiceCollection InstallCalculators(this IServiceCollection services)
    {

        InstallCalculators(services, AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }

    public static IServiceCollection InstallCalculators(this IServiceCollection services,params Assembly[] assemblies)
    {
        if (!assemblies.Any())
        {
            throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for calculators.");
        }
      
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c =>
                c.AssignableTo(typeof(ICalculator<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()
            .AddClasses(c=>c.AssignableTo(typeof(ICalculator<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        return services;
    }
}