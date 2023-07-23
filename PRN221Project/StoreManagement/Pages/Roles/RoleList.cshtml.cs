using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreManagement.Pages.Roles
{
    [Authorize(Roles="Admin")]
    public class RoleListModel : PageModel
    {
        private RoleManager<IdentityRole> _roleManager;
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public RoleListModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public List<IdentityRole> roles { get; set; }
        public void OnGet()
        {
            if(Name != null)
            {
                if (!_roleManager.RoleExistsAsync(Name).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(Name)).GetAwaiter().GetResult();
                }
                Name = "";
            }          
            roles = _roleManager.Roles.ToList();
        }
    }
}
