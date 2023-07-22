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
        public void DeleteEmployee(int id) => DAO.Instance.Delete(id);

        public Employee GetEmployee(int id) => DAO.Instance.GetEmployeeByID(id);

        public IEnumerable<Employee> GetEmployeeList() => DAO.Instance.GetEmployeeList();
    }
}
