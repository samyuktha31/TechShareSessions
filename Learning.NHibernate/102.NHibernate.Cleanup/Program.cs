namespace _102.NHibernate.Cleanup
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // INSERT a new customer
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Inserting a new customer...!");
                Console.WriteLine("-----------------------------------------------------");
                var customer = new Customer { FirstName = "Kannan", LastName = "Perumal" };
                CustomerRepository.Add(ref customer);
                // Id will be reflecting in Id property using the NHibernate magic! This will work for both Insert and Update
                Console.WriteLine("Id of new customer is: {0}", customer.Id);
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("*");
            }

            // READ all customers
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Reading all customers...!");
                Console.WriteLine("-----------------------------------------------------");
                var customers = CustomerRepository.GetAll();
                foreach (var customer in customers)
                {
                    Console.WriteLine("Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                }
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("*");
            }

            // UPDATE a customer
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Updating a customer...!");
                Console.WriteLine("-----------------------------------------------------");
                var customer = new Customer { FirstName = "Kannan", LastName = "Perumal" };
                if(CustomerRepository.Update("Kannan", "MrKannan"))
                {
                    Console.WriteLine("Updated successfully!");
                }
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("*");
            }

            // READ all customers
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Reading all customers...!");
                Console.WriteLine("-----------------------------------------------------");
                var customers = CustomerRepository.GetAll();
                foreach (var customer in customers)
                {
                    Console.WriteLine("Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                }
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("*");
            }

            // DELETE customers with first name 'Kannan'
            {
                string nameFilter = "MrKannanazxs";
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Deleting all customers with firstName '{0}'...!", nameFilter);
                Console.WriteLine("-----------------------------------------------------");
                
                if (CustomerRepository.Delete(nameFilter))
                {
                    Console.WriteLine("Deleted customers with first name: {0}", nameFilter);
                }
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("*");
            }

            // READ all customers
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Reading all customers...!");
                Console.WriteLine("-----------------------------------------------------");
                var customers = CustomerRepository.GetAll();
                foreach (var customer in customers)
                {
                    Console.WriteLine("Id: {0}, FirstName: {1}, LastName: {2}", customer.Id, customer.FirstName, customer.LastName);
                }
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("*");
            }
        }
    }
}
