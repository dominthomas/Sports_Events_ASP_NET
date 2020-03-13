using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsEvents.Models;
namespace Sports_Events_ASP_NET.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home() => View();

        public IActionResult Event() => View();
    }
}
