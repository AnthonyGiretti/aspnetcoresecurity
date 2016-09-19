using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Demo_CoreSecurity_Autorization.Models;
using Demo_CoreSecurity_Autorization.Models.AccountViewModels;
using Demo_CoreSecurity_Autorization.Services;

namespace Demo_CoreSecurity_Autorization.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Login()
        {
            var identity = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Role,"Administrator"),
                new Claim(ClaimTypes.NameIdentifier, "Anthony Giretti"),
                new Claim(ClaimTypes.Name, "Anthony :)")

            }, "CustomIdentity");

            await HttpContext.Authentication.SignInAsync("MSDEVMTL", new ClaimsPrincipal(identity));

            return View();
        }

        [Authorize]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync("MSDEVMTL");

            return View();
        }

        public async Task<IActionResult> Forbidden()
        {
            return View();
        }
    }
}


