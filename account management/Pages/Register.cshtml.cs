using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace account_management.Pages
{
    public class RegisterModel : PageModel
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

      

        public void OnPost() {
            // Logic for registering user

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
