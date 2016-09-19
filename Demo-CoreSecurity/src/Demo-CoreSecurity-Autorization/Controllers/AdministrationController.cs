using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Demo_CoreSecurity_Autorization.Controllers
{
    public class AdministrationController : Controller
    {
        [Authorize(Policy = "Administrators")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "SuperAdministrator")]
        public IActionResult TopSecret()
        {
            return View();
        }

        [Authorize(Policy = "AnthonyGirettiOnly")]
        public IActionResult OnlyAnthony()
        {
            return View();
        }
    }
}



