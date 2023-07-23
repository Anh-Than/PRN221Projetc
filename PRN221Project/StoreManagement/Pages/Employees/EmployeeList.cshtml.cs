using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.DataAcces;
using StoreManagement.Repository;

namespace StoreManagement.Pages.Employees
{
    [Authorize(Roles="Admin")]
    public class EmployeeListModel : PageModel
    {
        EmployeeRepository employeeRepository;
        public List<EmployeeView> employees;
        public void OnGet()
        {
            employeeRepository = new EmployeeRepository();
            employees = employeeRepository.GetEmployeesList();
        }

        public IActionResult OnGetAdd()
        {
            return RedirectToPage("/Employees/EmployeeAdd");
        }
    }
}
