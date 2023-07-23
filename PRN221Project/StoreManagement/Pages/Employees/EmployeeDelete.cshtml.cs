using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.DataAcces;
using System.Data;

namespace StoreManagement.Pages.Employees
{
    [Authorize(Roles = "Admin")]
    public class EmployeeDeleteModel : PageModel
    {

        NorthwindContext _context;
        public IActionResult OnGet(int id)
        {

            _context = new NorthwindContext();
            Employee e = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            _context.Employees.Remove(e);
            _context.SaveChanges();
            return RedirectToPage("/Employees/EmployeeList");
        }
    }
}
