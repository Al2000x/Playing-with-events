using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Delegate
{
    public delegate int MyDelegate(int n1, int n2);
    public delegate void ErrAlertHandler();
    public delegate void CompAlertHandler(int num);
    public delegate void StartAlertHandler(int num , int num2 , string txt);
    public class Calculator
    {
        public event StartAlertHandler StartedCalculation;
        public event CompAlertHandler CompletedCalculation;
        public event ErrAlertHandler Error;

        protected virtual int OnStartCalc(int a, int b ,string op) {
            switch (op)
            {
                case "+":
                  return Add(a, b);                    
                case "-":
                  return Sub(a, b);                    
                case "*":
                  return Mul(a, b);                    
                default:
                  return (-1);
                    
            }
        }
        public void start(int timeToRun)
        {
            Console.WriteLine("please insert the first number number");
            int.TryParse(Console.ReadLine(), out int n1);
            Console.Clear();
            Console.WriteLine("please insert a number");
            int.TryParse(Console.ReadLine(), out int n2);
            Console.Clear();
            Console.WriteLine("please choose an operator ( + || - || *)");
            string op = Console.ReadLine();
            while (op == null)
            {
                OnError_Calc();
                op = Console.ReadLine();
            }
            int res = OnStartCalc(n1,n2,op);
            Console.Clear();
            for (int i = 0; i < timeToRun; i++)
            {
                OnStart_Calc(n1, n2,op);
                
            }
            OnComp_Calc(res);
        }



        protected virtual void OnStart_Calc(int n1,int n2 ,string op)
        {

            StartAlertHandler al1 = StartedCalculation as StartAlertHandler;
            if (al1 == null)
            {
                return;
            }
            al1(n1, n2, op);
        }
        protected virtual void OnComp_Calc(int res)
        {
            CompAlertHandler al2 = CompletedCalculation as CompAlertHandler;
            if(al2 == null)
            {
                return;
            }
            al2(res);
            
            
        }
        protected virtual void OnError_Calc()
        {
            ErrAlertHandler al3 = Error as ErrAlertHandler;
            if (al3== null)
            {
                return;
            }
            al3();
        }

          


        static int Add(int n1, int n2)
        {
            return n1 + n2;

        }
        static int Sub(int n1, int n2)
        {
            return n1 - n2;

        }
        static int Mul(int n1, int n2)
        {
            return n1 * n2;

        }
    }
   


}
