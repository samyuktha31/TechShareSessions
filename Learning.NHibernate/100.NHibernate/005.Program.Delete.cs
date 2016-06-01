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
            var dbConnectionSessionFactory = configuration.BuildSessionFactory();
            
            // INSERT a row in table
            using (var dbConnectionSession = dbConnectionSessionFactory.OpenSession())
            using (var transaction = dbConnectionSession.BeginTransaction())
            {
                // Perform database interactions

                var customer = new Customer { FirstName = "Evil", LastName = "Kannan" };
                dbConnectionSession.Save(customer);

                // Id will be reflecting in Id property using the NHibernate magic! This will work for both Insert and Update
                Console.WriteLine("Id of new customer is: {0}", customer.Id);

                // This method will commit the underlying transaction if and only if the transaction was initiated by this 'transaction' object.
                transaction.Commit();
            }

            // READ rows from table
            using (var dbConnectionSession = dbConnectionSessionFactory.OpenSession())
            using (var transaction = dbConnectionSession.BeginTransaction())
            {
                // Object chaining way of using LINQ
                var customers = dbConnectionSession.Query<Customer>().Select(customer => customer);

                foreach (var customer in customers)
                {
                    Console.WriteLine("Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                }

                // This method will commit the underlying transaction if and only if the transaction was initiated by this 'transaction' object.
                // transaction.Commit();
            }

            // DELETE a row from table
            using (var dbConnectionSession = dbConnectionSessionFactory.OpenSession())
            using (var transaction = dbConnectionSession.BeginTransaction())
            {
                // Perform database interactions
                var customers = from customer in dbConnectionSession.Query<Customer>()
                                where customer.FirstName == "Evil"
                                select customer;
                //var firstCustomer = customers.First<Customer>();
                //dbConnectionSession.Delete(firstCustomer)

                foreach (var customer in customers)
                {
                    Console.WriteLine("DELETING: Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                    dbConnectionSession.Delete(customer);
                }

                // This method will commit the underlying transaction if and only if the transaction was initiated by this 'transaction' object.
                transaction.Commit();
            }

            // READ rows from table
            using (var dbConnectionSession = dbConnectionSessionFactory.OpenSession())
            using (var transaction = dbConnectionSession.BeginTransaction())
            {
                // Object chaining way of using LINQ
                var customers = dbConnectionSession.Query<Customer>().Select(customer => customer);

                foreach (var customer in customers)
                {
                    Console.WriteLine("Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                }

                // This method will commit the underlying transaction if and only if the transaction was initiated by this 'transaction' object.
                transaction.Commit();
            }
        }
    }
}
