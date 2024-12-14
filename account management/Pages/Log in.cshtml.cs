using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace account_management.Pages
{
    public class Log_inModel : PageModel
    {
        private static List<Account> accounts = new List<Account>
        {
            new Account { Email = "user1@example.com", Pass = "1" },
            new Account { Email = "user2@example.com", Pass = "2" },
            new Account { Email = "user3@example.com", Pass = "3" },
            new Account { Email = "user4@example.com", Pass = "4" },
            new Account { Email = "user5@example.com", Pass = "5" }
        };

        [BindProperty]
        public Account account{  get; set; }

        public string text = "NOT LOGGED IN (Use user1@example.com , 1)";

        public bool loggedin = false;
        public IActionResult OnGet()
        {
            // If the user is already logged in skip to DisplayLogin
            if (User.FindFirstValue(ClaimTypes.Email) != null)
            {
                loggedin = true;
                text = "Already Logged In as " + User.FindFirstValue(ClaimTypes.Email);

                return RedirectToPage("/DisplayLogin");

            }

            return Page();
        }

        public IActionResult OnPost() {

            // Search through accounts to find matching credentials
            loggedin = accounts.Any(a => a.Email.Equals(account.Email, System.StringComparison.OrdinalIgnoreCase) && a.Pass == account.Pass);
            if (loggedin)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, account.Email)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync("CookieLoginScheme", claimsPrincipal);
                text = "Logged In";
                return RedirectToPage("/DisplayLogin");
            }

            return Page();
        }

        public IActionResult OnGetSignInGoogle()
        {
            // This method will be called when the user clicks the "Sign in with Google" link
            var redirectUrl = Url.Page("/DisplayLogin");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);

        }

        //public async Task<IActionResult> OnGetAsync()
        //{
        //    // This method will handle the response from Google after authentication
        //    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    if (result.Succeeded)
        //    {
        //        var email = result.Principal.FindFirstValue(ClaimTypes.Email);
        //        var name = result.Principal.FindFirstValue(ClaimTypes.Name);

        //        Console.WriteLine($"Email: {email}");
        //        Console.WriteLine($"Name: {name}");

        //        return RedirectToPage("/DisplayLogin");
        //    }

        //    return RedirectToPage("/Register");
        //}


    }
}
