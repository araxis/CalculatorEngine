using CalculatorEngine.Abstract;

namespace CalculatorEngine;

internal interface IWrapper{}
internal interface ICalculatorWrapper<TResult> :IWrapper
{
    Task<TResult> Calc(object param,CancellationToken cancellationToken);
}

internal interface ICalculatorWrapper : IWrapper
{
    Task Calc(object param, CancellationToken cancellationToken);
}

internal class CalculatorWrapper<TParam, TResult> : ICalculatorWrapper<TResult> where TParam : IParam<TResult>
{
    private readonly ICalculator<TParam, TResult> _calculator;

    public CalculatorWrapper(ICalculator<TParam, TResult> calculator)
    {
        _calculator = calculator;
    }

    public  async  Task<TResult> Calc(object param,CancellationToken cancellationToken) =>
        await _calculator.Calc((TParam)param,cancellationToken).ConfigureAwait(false);

  
}


internal class CalculatorWrapper<TParam> : ICalculatorWrapper where TParam : IParam
{
    private readonly ICalculator<TParam> _calculator;

    public CalculatorWrapper(ICalculator<TParam> calculator)
    {
        _calculator = calculator;
    }

    public async Task Calc(object param, CancellationToken cancellationToken) =>
        await _calculator.Calc((TParam)param, cancellationToken).ConfigureAwait(false);


}