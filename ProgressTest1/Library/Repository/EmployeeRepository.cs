using Library.BussinessObject;
using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Department> GetDepartments() => EmployeeDBContext.Instance.GetDepartments();

        public IEnumerable<Employee> GetEmployees() => EmployeeDBContext.Instance.GetEmployeeList();

        public List<string> GetPositions() => EmployeeDBContext.Instance.GetPositions();
    }
}
