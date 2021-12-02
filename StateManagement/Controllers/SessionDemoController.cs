using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.Controllers
{
    public class SessionDemoController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("name", "Rahul");
            HttpContext.Session.SetInt32("age", 22);
            return RedirectToAction(nameof(Welcome));
        }
        public IActionResult Welcome()
        {
            string name = HttpContext.Session.GetString("name");
            int age = HttpContext.Session.GetInt32("age").Value;
            ViewBag.Name = name;
            ViewBag.Age = age;

            return View();
        }
    }
}
