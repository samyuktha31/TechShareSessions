using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Reflection;

namespace _100.NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            NHibernateProfiler.Initialize();

            var configuration = new Configuration();
            configuration.DataBaseIntegration(x => {
                x.ConnectionString = "Server=localhost;Database=NHibernageDemo;Integrated Security=SSPI;";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
                x.LogSqlInConsole = true;
            });

            // Add all the models
            configuration.AddAssembly(Assembly.GetExecutingAssembly());

            // Puts in place all the metadata that is required to initialize NHibernate
            // Using this sessionFactory, one can build sessions, which is similar to database connections.
            var sessionFactory = configuration.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                // Perform database interactions
                var query = from customer in session.Query<Customer>()
                            where customer.FirstName == "Murugan"
                            select customer;

                var qcustomer = query.First();
                qcustomer.FirstName = "Karia Murugan";

                session.Update(qcustomer);

                transaction.Commit();
            }

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                // Perform database interactions
                var query = from customer in session.Query<Customer>()
                            where customer.FirstName == "Karia Murugan"
                            select customer;

                var qcustomer = query.First();
                qcustomer.FirstName = "Murugan";

                session.Update(qcustomer);

                transaction.Commit();
            }

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                // Perform database interactions

                // // Object chaining way of using LINQ
                // var customers = session.Query<Customer>().Select(customer => customer);

                // // LINQ query comprehensions
                var customers = from customer in session.Query<Customer>()
                                //where customer.LastName.Length > 7
                                orderby customer.LastName
                                select customer;

                foreach (var customer in customers)
                {
                    Console.WriteLine("Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                }

                transaction.Commit();
            }
        }
    }
}
