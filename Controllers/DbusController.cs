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
        public IActionResult Form() => View();

        public IActionResult Results(string type, string sender, string @interface) => View(new ResultsViewModel() { Type = type, Sender = sender, Interface = @interface });

        public async Task<IActionResult> ResultsAjax(string type, string sender, string @interface)
        {
            var args = string.Empty;

            if (!string.IsNullOrEmpty(type))
            {
                args += $"\"type='{type}'\""; 
            }

            if (!string.IsNullOrEmpty(sender))
            {
                if(!string.IsNullOrEmpty(args))
                {
                    args += ", ";
                }
                args += $"\"sender='{sender}'\"";
            }

            if (!string.IsNullOrEmpty(@interface))
            {
                if(!string.IsNullOrEmpty(args))
                {
                    args += ", ";
                }
                args += $"\"sender='{@interface}'\"";
            }

            if (!ProcessesMap.Map.ContainsKey(args))
            {
                AddProcess(args);
            }

            string line = null;

            try
            {
                var output = ProcessesMap.Map[args].StandardOutput;
                line = await output.ReadLineAsync();
            }
            catch (Exception)
            {
                AddProcess(args);
                var output = ProcessesMap.Map[args].StandardOutput;
                line = await output.ReadLineAsync();
            }

            return Json(line?.ToString() ?? string.Empty);
        }

        private void AddProcess(string args)
        {
            var proc = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("dbus-monitor", args) {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    }
                );
                ProcessesMap.Map[args] = proc;
        }
    }
}