using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace account_management.Pages
{
    public class AdminModel : PageModel
    {
        private static List<Account> accounts = new List<Account>
        {
            new Account { Email = "admin1@example.com", Pass = "1" },
            new Account { Email = "admin2@example.com", Pass = "2" },
            new Account { Email = "admin3@example.com", Pass = "3" },
            new Account { Email = "admin4@example.com", Pass = "4" },
            new Account { Email = "admin5@example.com", Pass = "5" }
        };

        [BindProperty]
        public Account account { get; set; }

        public string text = "NOT LOGGED IN";

        public bool loggedin = false;
        public void OnGet()
        {

        }

        public void OnPost()
        {
            // Search through accounts to find matching credentials

            foreach (Account a in accounts)
            {
                if (a.Email.Equals(account.Email) && a.Pass.Equals(account.Pass))
                {
                    Console.WriteLine("Success");
                }

                Console.WriteLine(account.Pass + "  " + a.Pass);
            }

            loggedin = accounts.Any(a => a.Email.Equals(account.Email, System.StringComparison.OrdinalIgnoreCase) && a.Pass == account.Pass);
            if (loggedin)
            {
                text = "Logged In";
            }
        }

    }
}