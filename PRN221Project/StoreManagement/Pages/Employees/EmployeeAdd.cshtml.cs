using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.DataAcces;
using StoreManagement.Repository;
using StoreManagement.ViewModel;
using System.Data;

namespace StoreManagement.Pages.Employees
{
    [Authorize(Roles = "Admin")]
    public class EmployeeAddModel : PageModel
    {
        EmployeeRepository employeeRepository;
        [BindProperty(SupportsGet = true)]
        public List<string> Titles { get; set; }

        [BindProperty]
        public AddEmployeeView AddEmployeeView { get; set; }
        public void OnGet()
        {
            employeeRepository = new EmployeeRepository();
            Titles = employeeRepository.GetTitlesList();
        }

        public IActionResult OnPost()
        {
            employeeRepository = new EmployeeRepository();
            var employee = new Employee
            {
                LastName = AddEmployeeView.LastName,
                FirstName = AddEmployeeView.FirstName,
                Title = AddEmployeeView.Title,
                BirthDate = AddEmployeeView.Dob
            };
            employeeRepository.AddEmployee(employee);
            return RedirectToPage("/Employees/EmployeeList");
        }
    }
}
