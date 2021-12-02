using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //reading cookie from request object
            string unm = Request.Cookies["unm"];
            string textcolor = Request.Cookies["textcolor"];
            UserPreference up = new UserPreference();
            up.color = unm;
            up.textcolor = textcolor;
            

            return View("Index",unm);
        }
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            //reading cookie from request object
            string unm = form["unm"].ToString();
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("unm", unm, options);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveCookie()
        {
            Response.Cookies.Delete("unm");
            return View("Index");

        }
    }
}
