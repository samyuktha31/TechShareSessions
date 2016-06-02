using System;
using System.Threading;

namespace _100.Singleton
{
    class Program
    {
        private static Employee ceo = new Employee
        {
            Id= 1,
            FirstName = "Ashwini",
            LastName = "Maddala"
        };

        private static Employee cfo = new Employee
        {
            Id = 2,
            FirstName = "Roger",
            LastName = "Grobler"
        };

        static void Main(string[] args)
        {
            var t1 = new Thread(() =>
            {
                Worker(ceo);
            });
            var t2 = new Thread(() =>
            {
                Worker(cfo);
            });

            t1.IsBackground = false;
            t2.IsBackground = false;

            t1.Start();
            t2.Start();
        }

        private static void Worker(Employee employee)
        {
            int counter = 10000;
            while (counter-- != 0)
            {
                Printer.Print(employee.ToString());
            }
        }
    }
}
