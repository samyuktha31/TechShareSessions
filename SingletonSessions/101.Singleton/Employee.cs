using System;
using System.Text;

namespace _101.Singleton
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return new StringBuilder().Append("Id: ").Append(Id)
                .Append(" Name: ").Append(FirstName)
                .Append(" ").Append(LastName)
                .ToString();
        }

        public void PrintInfo()
        {
            Printer.Instance.Print(ToString());
            
        }
    }
}