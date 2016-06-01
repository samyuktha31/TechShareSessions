namespace _102.NHibernate.Cleanup
{
    using global::NHibernate.Linq;
    using System;
    using System.Linq;

    public static class CustomerRepository
    {
        public static void Add(ref Customer customer)
        {
            using (var dbConnectionSession = NHibernateManager.GetSessionFactory().OpenSession())
            using (var transaction = dbConnectionSession.BeginTransaction())
            {
                dbConnectionSession.Save(customer);
                transaction.Commit();
            }
        }

        public static Customers GetAll()
        {
            Customers allCustomers = new Customers();

            using (var dbConnectionSession = NHibernateManager.GetSessionFactory().OpenSession())
            using (var transaction = dbConnectionSession.BeginTransaction())
            {
                // Object chaining way of using LINQ
                // NOTE: Shall be refactored to make it more performant!
                var customers = dbConnectionSession.Query<Customer>().AsEnumerable();
                
                foreach(var customer in customers)
                {
                    allCustomers.Add(customer);
                }
            }

            return allCustomers;
        }

        public static bool Delete(string firstName)
        {
            bool isDeleted = false;

            using (var dbConnectionSession = NHibernateManager.GetSessionFactory().OpenSession())
            using (var transaction = dbConnectionSession.BeginTransaction())
            {
                var customers = from customer in dbConnectionSession.Query<Customer>()
                                where customer.FirstName == firstName
                                select customer;

                //var firstCustomer = customers.First<Customer>();
                //dbConnectionSession.Delete(firstCustomer)

                foreach (var customer in customers)
                {
                    Console.WriteLine("DELETING: Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                    dbConnectionSession.Delete(customer);

                    isDeleted = true;
                }

                // This method will commit the underlying transaction if and only if the transaction was initiated by this 'transaction' object.
                transaction.Commit();
            }

            return isDeleted;
        }

        public static bool Update(string firstName, string newFirstName)
        {
            bool isUpdated = false;

            using (var dbConnectionSession = NHibernateManager.GetSessionFactory().OpenSession())
            using (var transaction = dbConnectionSession.BeginTransaction())
            {
                var customers = from customer in dbConnectionSession.Query<Customer>()
                                where customer.FirstName == firstName
                                select customer;

                var customerToBeUpdated = customers.FirstOrDefault();
                if (null != customerToBeUpdated)
                {
                    customerToBeUpdated.FirstName = newFirstName;
                    isUpdated = true;
                }

                dbConnectionSession.Update(customerToBeUpdated);

                transaction.Commit();
            }

            return isUpdated;
        }
    }
}