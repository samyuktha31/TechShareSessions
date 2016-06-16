using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplicationDemo1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        ////public string Index(string id, string name)
        ////{
        ////    return "First MVC Application " + id + " " + name;
        ////}

        ////public List<string> Index()
        ////{
        ////    ////Printing the type
        ////    return new List<string>()
        ////    {
        ////        "India",
        ////        "US",
        ////        "Canada"
        ////    };
        ////}

        public ActionResult Index()
        {
            ViewBag.Countries = new List<string>()
            {
                "India",
                "US",
                "Canada"
            };

            return View();
        }

    }
}
