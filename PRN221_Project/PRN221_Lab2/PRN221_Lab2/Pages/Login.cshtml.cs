using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Lab2.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Account account { get; set; }
        public List<Account> accounts { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Account account)
        {
            accounts = new List<Account> { 
            new Account{UserName = "admin", Password = "123"},
            new Account{UserName = "user", Password = "123"}
            };
            foreach (Account a in accounts)
            {
                if (a.UserName.Equals(account.UserName) && a.Password.Equals(account.Password))
                {
                    HttpContext.Session.SetString("username", account.UserName);
                    return RedirectToPage("/Shop/ProductsList");
                }
            }
            return Page();
        }

        public class Account
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public Account(string userName, string password)
            {
                UserName = userName;
                Password = password;
            }

            public Account()
            {
            }
        }
    }
}
