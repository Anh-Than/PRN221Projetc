using StoreManagement.DataAcces;

namespace StoreManagement.Repository
{
    public class EmployeeRepository
    {
        NorthwindContext _context = new NorthwindContext();
        public List<EmployeeView> GetEmployeesList()
        {
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
    }
}
