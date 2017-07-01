using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projekt_ps_DBUS.ViewModels;

namespace projekt_ps_DBUS.State
{
    public static class ProcessesMap
    {
        public static readonly Dictionary<string, Process> Map = new Dictionary<string, Process>();
    }
}