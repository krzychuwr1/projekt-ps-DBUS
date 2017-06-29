using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace projekt_ps_DBUS.ViewModels
{
    public class ResultsViewModel
    {
        public string Type { get; set; }

        public string Sender { get; set; }

        public string Interface { get; set; }
    }
}
