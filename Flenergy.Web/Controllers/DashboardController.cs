using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flenergy.Web.Controllers
{
    public class DashboardController : Controller 
    {
        public IActionResult Global() =>  View();
        public IActionResult Admin() =>  View();
        public IActionResult Customer() =>  View();
    }
}
