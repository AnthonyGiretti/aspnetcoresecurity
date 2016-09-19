using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection;
using System.Threading;

namespace Demo_CoreSecurity_DataProtection.Controllers
{
    public class HomeController : Controller
    {
        private IDataProtector _protector;

        public HomeController(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("MyProtector");
        }

        public IActionResult Index()
        {
            var data = "Hello world!";
            var protectedData = _protector.Protect(data);
            var unprottectedData = _protector.Unprotect(protectedData);
            var hashedData = CustomHash.Hash(data,"MSDEVMTLHASHKEY");

            ViewData["data"] = data;
            ViewData["protectedData"] = protectedData;
            ViewData["unprottectedData"] = unprottectedData;
            ViewData["hashedData"] = hashedData;

            return View();
        }

       
    }
}
