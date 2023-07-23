using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.DataAcces;

namespace StoreManagement.Pages.Shop
{
    [Authorize(Roles="Admin")]
    public class DasboardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
