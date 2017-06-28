using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projekt_ps_DBUS.State;
using projekt_ps_DBUS.ViewModels;

namespace projekt_ps_DBUS.Controllers
{
    public class DbusController : Controller
    {
        private static StreamReader output;

        public IActionResult Results(string type) => View(new ResultsViewModel() { Type = type });

        public async Task<IActionResult> ResultsAjax(string type)
        {
            var args = $"\"type='{type}'\"";
            if(!ProcessesMap.Map.ContainsKey(args))
            {
                var proc = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("dbus-monitor", args) {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    }
                );
                ProcessesMap.Map.Add(args, proc);
            }

            var output = ProcessesMap.Map[args].StandardOutput;

            var line = await output.ReadLineAsync();

            return Json(line?.ToString());
        }
    }
}