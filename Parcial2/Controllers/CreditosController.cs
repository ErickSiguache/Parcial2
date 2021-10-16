using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2.Controllers
{
    public class CreditosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
