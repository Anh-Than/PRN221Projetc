using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreManagement.DataAcces;
using StoreManagement.Repository;
using StoreManagement.ViewModel;
using System;
using System.Data;

namespace StoreManagement.Pages.Employees
{
    [Authorize(Roles = "Admin")]
    public class EmployeeEditModel : PageModel
    {
        EmployeeRepository employeeRepository;
        [BindProperty(SupportsGet = true)]
        public List<string> Titles { get; set; }
        [BindProperty]
        public EditEmployeeView EditEmployeeView { get; set; }
        public void OnGet(int id)
        {
            employeeRepository = new EmployeeRepository();
            Titles = employeeRepository.GetTitlesList();
            EditEmployeeView = employeeRepository.GetEmployeeByID(id);
        }

        public IActionResult OnPost(EditEmployeeView employee)
        {
            NorthwindContext _context = new NorthwindContext();
            employeeRepository = new EmployeeRepository();
            if (employee != null)
            {
                var existingEmployee = employeeRepository.GetEmployeeByIDModel(employee.Id);
                if(existingEmployee != null)
                {
                    existingEmployee.FirstName = employee.FirstName;
                    existingEmployee.LastName = employee.LastName;
                    existingEmployee.Title = employee.Title;
                    existingEmployee.BirthDate = employee.Dob;
                    _context.Entry(existingEmployee).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToPage("/Employees/EmployeeList");
        }
    }
}
