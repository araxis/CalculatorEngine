namespace CalculatorEngine.Abstract;



public abstract class Calculator<TParam, TResult> : ICalculator<TParam, TResult> where TParam : IParam<TResult>
{
    protected abstract TResult Calc(TParam param);
    public Task<TResult> Calc(TParam param, CancellationToken cancellationToken) => Task.FromResult(Calc(param));
}

public abstract class Calculator<TParam> : ICalculator<TParam> where TParam : IParam
{
    protected abstract Task Calc(TParam param);
    public Task Calc(TParam param, CancellationToken cancellationToken) => Task.FromResult(Calc(param));
}

[Obsolete("Use class Calculator", false)]
public abstract class SyncCalculator<TParam, TResult> : ICalculator<TParam, TResult> where TParam : IParam<TResult>
{
    protected abstract TResult Calc(TParam param);
    public Task<TResult> Calc(TParam param, CancellationToken cancellationToken) => Task.FromResult(Calc(param));
}