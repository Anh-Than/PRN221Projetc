using StoreManagement.DataAcces;
using StoreManagement.ViewModel;

namespace StoreManagement.Repository
{
    public class EmployeeRepository
    {

        public List<EmployeeView> GetEmployeesList()
        {
            NorthwindContext _context = new NorthwindContext();
            List<Employee> employees = new List<Employee>();
            List<EmployeeView> employeeList = new List<EmployeeView>();
            employees = _context.Employees.ToList();
            EmployeeView e;
            foreach (Employee employee in employees)
            {
                DateTime dob = (DateTime)employee.BirthDate;
                e = new EmployeeView
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    BirthDate = dob.ToString("dd/MM/yyyy"),
                };
                employeeList.Add(e);
            }
            return employeeList;
        }

        public List<EmployeeForGraph> GetEmployeesForGraph()
        {
            NorthwindContext _context = new NorthwindContext();
            List<EmployeeForGraph> employeesForGraph = new List<EmployeeForGraph>();
            List<EmployeeView> emps = new List<EmployeeView>();
            emps = GetEmployeesList();

            EmployeeForGraph employeeForGraph;

            foreach (EmployeeView emp in emps)
            {
                if (!employeesForGraph.Any(eg => eg.Title == emp.Title))
                {
                    employeeForGraph = new EmployeeForGraph
                    {
                        Title = emp.Title,
                        Employees = 1
                    };
                    employeesForGraph.Add(employeeForGraph);
                }
                else
                {
                    employeesForGraph.FirstOrDefault(eg => eg.Title == emp.Title).Employees++;
                }
            }

            return employeesForGraph;
        }

        public List<string> GetTitlesList()
        {
            List<EmployeeView> emps = new List<EmployeeView>();
            emps = GetEmployeesList();
            List<string> titles = new List<string>();
            foreach (EmployeeView emp in emps)
            {
                if (!titles.Contains(emp.Title))
                {
                    titles.Add(emp.Title);
                }
            }
            return titles;
        }

        public void AddEmployee(Employee employee)
        {
            NorthwindContext _context = new NorthwindContext();
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public EditEmployeeView GetEmployeeByID(int id)
        {
            NorthwindContext _context = new NorthwindContext();
            Employee e = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            EditEmployeeView ew = new EditEmployeeView
            {
                Id = e.EmployeeId,
                LastName = e.LastName,
                FirstName = e.FirstName,
                Title = e.Title,
                Dob = (DateTime)e.BirthDate
            };
            return ew;
        }

        public Employee GetEmployeeByIDModel(int id)
        {
            NorthwindContext _context = new NorthwindContext();
            Employee emp = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            return emp;
        }
    }
}
