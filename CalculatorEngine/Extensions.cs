using System.Reflection;
using CalculatorEngine.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorEngine;

public static class Extensions
{
    public static IServiceCollection AddCalculator(this IServiceCollection services)
    {
       
        services.AddTransient<ICalcEngine, CalcEngine>();
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
            .WithTransientLifetime());
        return services;
    }
}