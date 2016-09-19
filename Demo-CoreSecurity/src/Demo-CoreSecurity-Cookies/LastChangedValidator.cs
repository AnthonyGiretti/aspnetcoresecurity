using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_CoreSecurity_Cookies
{
    public class LastChangedValidator
    {
        public static async Task ValidateAsync(CookieValidatePrincipalContext context) 
        {
            //Exemple
            //Pull user information from database
            //Look for the changes
            //Validate / unvalidate the cookie if the requirement are not fulfilled or user has been deactivated, etc....
            //Signout if cookie is unvalidated with await HttpContext.Authentication.SignOutAsync("MSDEVMTL");
        }
    }
}
