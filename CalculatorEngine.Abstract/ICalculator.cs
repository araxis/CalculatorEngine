namespace CalculatorEngine.Abstract;



public interface ICalculator<in TParam, TResult> where TParam : IParam<TResult>
{
    Task<TResult> Calc(TParam param, CancellationToken cancellationToken);
}

public interface ICalculator<in TParam> where TParam : IParam
{
    Task Calc(TParam param, CancellationToken cancellationToken);
}