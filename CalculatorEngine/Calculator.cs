using CalculatorEngine.Abstract;

namespace CalculatorEngine;



public abstract class Calculator<TParam,TResult>:ICalculator<TParam,TResult>  where TParam:IParam<TResult>
{
    protected abstract TResult Calc(TParam param);
    public Task<TResult> Calc(TParam param, CancellationToken cancellationToken) => Task.FromResult( Calc(param));
}

[Obsolete("Use class Calculator",false)]
public abstract class SyncCalculator<TParam,TResult>:ICalculator<TParam,TResult>  where TParam:IParam<TResult>
{
    protected abstract TResult Calc(TParam param);
    public Task<TResult> Calc(TParam param, CancellationToken cancellationToken) => Task.FromResult( Calc(param));
}