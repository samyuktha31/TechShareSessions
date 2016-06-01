using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _101.NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            // "hibernate.cfg.xml" should be in same path as executable
            ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();

            //ISessionFactory sessionFactory = new Configuration().Configure(@"..\..\hibernate.cfg.xml").BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                // Perform database interactions

                var customer = new Customer { FirstName = "Evil", LastName = "Kannan" };
                session.Save(customer);

                // Id will be reflecting in Id property using the NHibernate magic! This will work for both Insert and Update
                Console.WriteLine("Id of new customer is: {0}", customer.Id);

                transaction.Commit();
            }

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                // Object chaining way of using LINQ
                var customers = session.Query<Customer>().Select(customer => customer);

                foreach (var customer in customers)
                {
                    Console.WriteLine("Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                }

                transaction.Commit();
            }

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                // Perform database interactions
                var query = from customer in session.Query<Customer>()
                            where customer.FirstName == "Evil"
                            select customer;
                var qcustomer = query.First();

                session.Delete(qcustomer);

                transaction.Commit();
            }

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                // Object chaining way of using LINQ
                var customers = session.Query<Customer>().Select(customer => customer);

                foreach (var customer in customers)
                {
                    Console.WriteLine("Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                }

                transaction.Commit();
            }
        }
    }
}
