using System.Reflection;
using CalculatorEngine.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorEngine;

public static class Extensions
{
    public static IServiceCollection AddCalculator(this IServiceCollection services)
    {
       
        services.AddTransient<ICalcEngine, CalcEngine>();
        services.InstallCalculators( AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
    
}