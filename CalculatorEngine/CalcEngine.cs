using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorEngine;

internal class CalcEngine : ICalcEngine
{
    private static readonly ConcurrentDictionary<Type, IWrapper> CalculatorsCache = new();

    private readonly IServiceProvider _serviceProvider;

    public CalcEngine(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }



    public Task<TResult> Calc<TResult>(IParam<TResult> param, CancellationToken cancellationToken = default)
    {
        if (param is null)
            throw new ArgumentNullException(nameof(param));



        IWrapper CreateCalculator(Type type)
        {
            var wrapperType = typeof(CalculatorWrapper<,>).MakeGenericType(type, typeof(TResult));
            return (IWrapper)ActivatorUtilities.CreateInstance(_serviceProvider, wrapperType)!;
        }


        var calculator = CalculatorsCache.GetOrAdd(param.GetType(), CreateCalculator);
        return ((ICalculatorWrapper<TResult>)calculator).Calc(param, cancellationToken);

    }


}