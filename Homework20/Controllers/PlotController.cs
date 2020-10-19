using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Homework20.Controllers
{
    public class PlotController : Controller
    {
        public IActionResult Plot()
        {
            return View();
        }
    }
}
