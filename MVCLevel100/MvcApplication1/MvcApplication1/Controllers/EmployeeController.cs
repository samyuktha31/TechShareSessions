using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Util;

namespace MvcApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                List<Employee> employees = session.Query<Employee>().ToList();

                return View(employees);
            }
        }

        public ActionResult Get(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Employee employee = session.Query<Employee>().First(node => node.Id == id);
                return View(employee);
            }
        }

        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                return View(employee);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var employeetoUpdate = session.Get<Employee>(id);

                employeetoUpdate.Name = employee.Name;
                employeetoUpdate.Gender = employee.Gender;
                employeetoUpdate.City = employee.City;

                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(employeetoUpdate);
                    transaction.Commit();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
