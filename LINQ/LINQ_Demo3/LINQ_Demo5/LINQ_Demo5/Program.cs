using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Demo5
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();

            var names = from employee in dbContext.Employees
                where employee.Name.StartsWith("a")
                select employee.Name;

            foreach (var name in names)
            {
                Console.WriteLine("Names are:" + name);
            }
        }
    }
}
