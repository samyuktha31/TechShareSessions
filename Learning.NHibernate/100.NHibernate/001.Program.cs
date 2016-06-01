using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Reflection;

namespace _100.NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(x => {
                x.ConnectionString = "Server=localhost;Database=NHibernageDemo;Integrated Security=SSPI;";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
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

                // // Querying database through session object Criteria
                var customers = session.CreateCriteria<Customer>()
                    .List<Customer>();

                foreach(var customer in customers)
                {
                    Console.WriteLine("Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                }
                
                transaction.Commit();
            }
        }
    }
}
