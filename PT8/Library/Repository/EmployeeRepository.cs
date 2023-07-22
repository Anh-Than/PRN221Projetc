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
        public void AddNew(Employee employee) => EmployeeDAO.Instance.AddNew(employee);

        public Employee GetEmployeeByID(int id) => EmployeeDAO.Instance.GetEmployeeByID(id);

        public IEnumerable<Employee> GetEmployees() => EmployeeDAO.Instance.GetEmployeeList();

        public List<string> GetPosition() => EmployeeDAO.Instance.GetPositions();

        public void Update(Employee employee) => EmployeeDAO.Instance.Update(employee);
    }
}
