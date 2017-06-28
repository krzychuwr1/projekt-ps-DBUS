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
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Dbus()
        {
            var proc = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("dbus-monitor") {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                }
            );

            var line = await proc.StandardOutput.ReadLineAsync();

            return View("Dbus", line);
        }

        public IActionResult DbusPage() => View();

        public async Task<IActionResult> DbusAjax()
        {
            var proc = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("dbus-monitor") {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                }
            );

            var line = await proc.StandardOutput.ReadLineAsync();

            return Json(line);
        }
    }
}
