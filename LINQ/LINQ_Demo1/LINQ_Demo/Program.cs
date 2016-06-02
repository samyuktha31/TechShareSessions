using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

namespace LINQ_Demo
{
    class Program
    {
        private static void Main(string[] args)
        {
            var employee = new Details();

            employee.GetEmployeeDetails();
            employee.GetNamesList();
            employee.GetStudentsList();

            var employeeDetailsWithNoLinq = new DetailsWithoutLinq();

            employeeDetailsWithNoLinq.GetEmployeeDetails();

            var firstOrSingle = new FirstDefaultOrSingleDefault();

            firstOrSingle.firstOrDeafult();
            firstOrSingle.singleOrDeafult();
            
            Console.ReadKey();
        }
    }

    class Details
    {
        public void GetNamesList()
        {
            IList<string> namesList =
                new List<string>()
                {
                    "John Snow",
                    "Ramsay Snow",
                    "Tyrion Lanister",
                    "Sansa Stark",
                    "Danerys Targeryan"
                };

            IEnumerable<string> namesHasSnow = namesList.Where(name => name.Contains("Snow"));

            foreach (var name in namesHasSnow)
            {
                Console.WriteLine(name);
            }

            List<Department> departments = new List<Department>();
            departments.Add(new Department { DepartmentId = 1, Name = "Web Automation" });
            departments.Add(new Department { DepartmentId = 2, Name = "Checkout" });
            departments.Add(new Department { DepartmentId = 3, Name = "Competitive Intelligence" });
            departments.Add(new Department { DepartmentId = 4, Name = "Retail" });
            departments.Add(new Department { DepartmentId = 5, Name = "Media" });

            var departmentList = from d in departments
                                 where d.Name.StartsWith("R")
                                 select d;


            foreach (var dept in departmentList)
            {
                Console.WriteLine("Department Id = {0} , Department Name = {1}", dept.DepartmentId, dept.Name);
            }

        }

        public void GetEmployeeDetails()
        {
            LINQDataClassDataContext dbContext = new LINQDataClassDataContext();
            
            IEnumerable<Employee> employeEnumerable = from employee in dbContext.Employees
                                                      where employee.Name.Length > 5
                                                      select employee;

            IQueryable<Employee> employeQueryable = from employee in dbContext.Employees
                                                    where employee.Name.Length > 5
                                                    select employee;

         employeEnumerable = employeEnumerable.Take(2);
            employeQueryable = employeQueryable.Take(2);


            foreach (var employee in employeEnumerable)
            {
                Console.WriteLine(employee.Name);
            }

            foreach (var employee in employeQueryable)
            {
                Console.WriteLine(employee.Name);
            }
        }

        public void GetStudentsList()
        {
            IEnumerable<string> names =
                from student in XDocument.Load(@"E:\Bot Branches\LINQ_To_XML.xml").Descendants("Student")
                where (int) student.Element("TotalMarks") > 800
                orderby (int) student.Element("TotalMarks") descending
                select student.Element("Name").Value;

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }

    class DetailsWithoutLinq
    {
        public void GetNamesList()
        {
            IList<string> namesList =
                new List<string>()
                {
                    "John Snow",
                    "Ramsay Snow",
                    "Tyrion Lanister",
                    "Sansa Stark",
                    "Danerys Targeryan"
                };

            foreach (string name in namesList)
            {
                if (name.Contains("snow"))
                {
                    Console.WriteLine(name);
                }
            }


            List<Department> departments = new List<Department>();
            departments.Add(new Department { DepartmentId = 1, Name = "Web Automation" });
            departments.Add(new Department { DepartmentId = 2, Name = "Checkout" });
            departments.Add(new Department { DepartmentId = 3, Name = "Competitive Intelligence" });
            departments.Add(new Department { DepartmentId = 4, Name = "Retail" });
            departments.Add(new Department { DepartmentId = 5, Name = "Media" });

            foreach (var dept in departments)
            {
                if (dept.Name.StartsWith("R"))
                {
                    Console.WriteLine("Department Id = {0} , Department Name = {1}", dept.DepartmentId, dept.Name);
                }
            }

            Console.ReadKey();

        }

        public void GetEmployeeDetails()
        {
            LINQDataClassDataContext dbContext = new LINQDataClassDataContext();

            var query1 =
                dbContext.ExecuteCommand(@"SELECT UPPER(Name) FROM Employees WHERE Name LIKE 'A%' ORDER BY Name");

            var query2 = 
                dbContext.ExecuteCommand(
                @"SELECT UPPER(Name) FROM
                (
                   SELECT *, RN = row_number()
                   OVER (ORDER BY Name)
                   FROM Customer
                   WHERE Namese LIKE 'A%'
                ) A
                WHERE RN BETWEEN 21 AND 30
                ORDER BY Name");

            var linqQuery = from c in dbContext.Employees
                            where c.Name.StartsWith ("A")
                            orderby c.Name
                            select c.Name.ToUpper();

            var thirdPage = linqQuery.Skip(20).Take(10);

            //LINQ to SQL or Entity Framework, the translation engine will convert the query (that we composed in two steps) into a single SQL satement optimized for the database server
        }
    }

    class FirstDefaultOrSingleDefault
    {
        IList<string> list =
                new List<string>()
                {
                    "John Snow",
                    "Ramsay Snow",
                    "Tyrion Lanister",
                    "Sansa Stark",
                    "Danerys Targeryan"
                };

        public void singleOrDeafult()
        {
            IEnumerable<string> namesHasSnow = list.Where(name => name.Contains("Snow"));
            namesHasSnow.SingleOrDefault();
        }

        public void firstOrDeafult()
        {
            IEnumerable<string> namesHasSnow = list.Where(name => name.Contains("Snow"));
            namesHasSnow.FirstOrDefault();
        }
    }

    class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }

}
