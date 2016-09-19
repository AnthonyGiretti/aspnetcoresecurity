using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo_CoreSecurity_Cookies.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: /<controller>/
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            var identity = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Role,"Administrator"),
                new Claim(ClaimTypes.NameIdentifier, "Anthony Giretti"),
                new Claim(ClaimTypes.Name, "Anthony :)")

            },"CustomIdentity");

            await HttpContext.Authentication.SignInAsync("MSDEVMTL", new ClaimsPrincipal(identity));

            return View();
        }

        // GET: /<controller>/
        public async Task<IActionResult> WhatEver()
        {
            var result = await HttpContext.Authentication.GetAuthenticateInfoAsync("MSDEVMTL");
            ClaimsPrincipal principal = result.Principal;

            //Or
            //ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;


            List<string> listclaim = new List<string>();
            foreach (Claim claim in principal.Claims)
            {
                listclaim.Add("Claim : " + claim.Type + " = " + claim.Value);
            }
            ViewData["claimlist"] = listclaim;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync("MSDEVMTL");

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> UnAuthorized()
        {
            return View();
        }
    }


}