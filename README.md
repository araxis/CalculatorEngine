






## Calculator Engine
[![.NET](https://github.com/araxis/CalculatorEngine/actions/workflows/dotnet.yml/badge.svg)](https://github.com/araxis/CalculatorEngine/actions/workflows/dotnet.yml)
[![NuGet](https://img.shields.io/nuget/vpre/Arax.CalcEngine.svg)](https://www.nuget.org/packages/Arax.CalcEngine)
[![NuGet](https://img.shields.io/nuget/dt/Arax.CalcEngine.svg)](https://www.nuget.org/packages/Arax.CalcEngine) 

`CalcEngine` is designed to implement and ececute any type of calculator.

** in fact this library is just a simplified version of [MediatoR](https://github.com/jbogard/MediatR)

** Big Thanks to [Jimmy Bogard](https://github.com/jbogard)


### Installing CalcEngine

You should install [CalcEngine with NuGet](https://www.nuget.org/packages/Arax.CalcEngine):

    Install-Package Arax.CalcEngine
    
Or via the .NET Core command line interface:

    dotnet add package Arax.CalcEngine
    
    
## Add to ServiceCollection
```csharp
   //add engine and calculators in current assembly
   builder.Services.AddCalculator();
   
   //to add calculators from another assemplies
   builder.Services.InstallCalculators(assembly1,assembly2)
```
##  Make calculator 
```csharp
    //first define parameter with IParam<TResult>
    public record SumParam(double Left, double Right) : IParam<double>;
    
    //define calculator
    
  public class SumCalculator:ICalculator<SumParam,double>
  {
      public async Task<double> Calc(SumParam param,CancellationToken cancellationToken)
      {
          //do calculation 
          //return result
      }
  }
  
  //or for calculators that calculate synchronously
  
  public class SumCalculator:SyncCalculator<SumParam,double>
{
    protected override double Calc(SumParam param)
    {
        // calculation logic
       // return result
    }
}
  
```
## Use : inject ICalcEngine & use
```csharp
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ICalcEngine _calcEngine;
  
        public CalculatorController(ICalcEngine calcEngine)
        {
            _calcEngine = calcEngine;
         
        }

        [HttpGet(Name = "GetSum")]
        public async Task<double> Get(double left,double right)
        {
         
            var param=new SumParam(left, right);

            var result = await _calcEngine.Calc(param);
            return result;
        }
    }
```
