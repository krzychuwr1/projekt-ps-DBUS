using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace projekt_ps_DBUS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "D-Bus monitor allows you to monitor D-Bus right from your browser!";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
