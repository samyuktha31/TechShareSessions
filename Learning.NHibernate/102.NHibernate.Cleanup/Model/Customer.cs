namespace _102.NHibernate.Cleanup
{
    using System.Collections.ObjectModel;

    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }

    public class Customers : Collection<Customer> { }
}
