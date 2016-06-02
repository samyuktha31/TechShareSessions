using System.Threading;
using System;
using System.Threading.Tasks;

namespace _101.Singleton
{
    class Program
    {
        private static readonly Employee Ceo = new Employee
        {
            Id = 1,
            FirstName = "Ashwini",
            LastName = "Maddala"
        };

        private static readonly Employee Cfo = new Employee
        {
            Id = 2,
            FirstName = "Roger",
            LastName = "Grobler"
        };

        static void Main(string[] args)
        {
            var t1 = new Task(() =>
            {
                Worker(Ceo);
            });
            var t2 = new Task(() =>
            {
                Worker(Cfo);
            });


            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine("WaitAll Done! from parent thread");

            Printer.Instance = null;
        }

        private static void Worker(Employee employee)
        {
            int counter = 100;
            while (counter-- != 0)
            {
                Printer.Instance.Print(employee.ToString());
            }

            Console.WriteLine("Done! from thread");
        }
    }
}
