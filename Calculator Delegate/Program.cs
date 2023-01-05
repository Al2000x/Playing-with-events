using Calculator_Delegate;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            calc.StartedCalculation += new StartAlertHandler(Start_Calc);

            calc.Error += new ErrAlertHandler(Error_Calc);

            calc.CompletedCalculation += new CompAlertHandler(Comp_Calc);
            calc.start(1);
        }
        
        static void Start_Calc(int n1,int n2,string op)
        {
            Console.WriteLine($"calculating between {n1} {n2} with the chosen op {op} ");
        }
        static void Error_Calc()
        {
            Console.WriteLine($"there was a problem in picking the operator");
        }
        static void Comp_Calc(int num)
        {
            Console.WriteLine($"Completed calculating the sum is {num}");
          
        }

    }
}