using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationDemo1.Models;

namespace MvcApplicationDemo1.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Details()
        {
            Employee employee = new Employee()
            {
                EmployeeId = 101,
                Name = "Samyuktha",
                Gender = "Female",
                City = "Hyderabad",
            };

            return View(employee);
        }

    }
}
