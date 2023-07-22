using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployeeList();
        public void DeleteEmployee(int id);
        public Employee GetEmployee(int id);
    }
}
