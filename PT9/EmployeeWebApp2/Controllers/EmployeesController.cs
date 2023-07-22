using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Library.DataAccess;
using Library.Repository;

namespace EmployeeWebApp2.Controllers
{
    public class EmployeesController : Controller
    {
        IEmployeeRepository employeeRepository = null;
        public EmployeesController() => employeeRepository = new EmployeeRepository();

        // GET: EmployeesController
        public ActionResult Index()
        {
            var empList = employeeRepository.GetEmployeeList();
            return View(empList);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var emp = employeeRepository.GetEmployee(id.Value);
            if (emp == null)
                return NotFound();
            return View(emp);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                employeeRepository.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
