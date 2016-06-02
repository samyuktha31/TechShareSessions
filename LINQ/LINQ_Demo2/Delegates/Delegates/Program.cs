using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    class Program
    {
        delegate Int32 CalculateSumPointer(int a, int b);

        delegate void dPrint(string content);

        static void Main()
        {
            dPrint delPrint = Print;
            delPrint += Print2;
            delPrint += Print;

            foreach (var func in delPrint.GetInvocationList())
            {
                try
                {
                    func.Method.Invoke(null, new object[] {"hello"});
                }
                catch
                {

                }
            }

            Console.Read();
            //Console.WriteLine("111111");
            //delPrint -= Print;
            //delPrint.Invoke("Hello");
            //Console.WriteLine("222222222222");
            //delPrint -= Print;
            //delPrint.Invoke("Hello");
        }

        static void Mainx(string[] args)
        {
            //CalculateSum calculateSum = new CalculateSum();

            //CalculateSumPointer sumPointer = calculateSum.ReturnSum;

            CalculateSumPointer sumPointer = 
                delegate(int a, int b)
                {
                    return (a + b);
                };

            ////int area = sumPointer(20, 30); ---- Delegate two

            int sum = sumPointer.Invoke(20, 30);

            Console.WriteLine(sum); 

            //CalculateSumPointer sumPointer = (a, b) => a + b; ---- Lambda Expressions

            Console.ReadLine();
        }

        static void Print(string content)
        {
            Console.WriteLine(content);
        }

        static void Print2(string content)
        {
            throw new Exception("GRrrrrr!");
        }
    }

    //class CalculateSum
    //{
    //    public int ReturnSum(int a, int b)
    //    {
    //        return (a + b);
    //    }
    //}
}
