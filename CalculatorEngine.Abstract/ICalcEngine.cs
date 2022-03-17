namespace CalculatorEngine.Abstract;

public interface ICalcEngine
{
    Task<TResult> Calc<TResult>(IParam<TResult> param, CancellationToken cancellationToken = default);
}