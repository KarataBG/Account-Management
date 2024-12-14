using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Microsoft.AspNetCore.Identity;

namespace account_management.Pages
{
    [Authorize]
    public class DisplayLoginModel : PageModel
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public void OnGet()
        {
            // Display Email and Name to confirm login
            UserEmail = User.FindFirstValue(ClaimTypes.Email);
            UserName = User.FindFirstValue(ClaimTypes.Name);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostLogoutAsync()
        {

            await HttpContext.SignOutAsync("CookieLoginScheme");
            return RedirectToPage("/Register");

        }
    }
}
