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

        

    }
}
