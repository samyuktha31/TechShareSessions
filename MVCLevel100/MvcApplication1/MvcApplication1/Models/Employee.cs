using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Employee
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Gender { get; set; }

        public virtual string City { get; set; }
    }
}