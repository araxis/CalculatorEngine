namespace CalculatorEngine;

public abstract class SyncCalculator<TParam,TResult>:ICalculator<TParam,TResult>  where TParam:IParam<TResult>
{
    protected abstract TResult Calc(TParam param);
    public Task<TResult> Calc(TParam param, CancellationToken cancellationToken) => Task.FromResult( Calc(param));
}