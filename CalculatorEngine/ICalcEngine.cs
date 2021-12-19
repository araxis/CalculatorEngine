namespace CalculatorEngine;

public interface ICalcEngine
{
    Task<TResult> Calc<TResult>(IParam<TResult> param,CancellationToken cancellationToken);
}