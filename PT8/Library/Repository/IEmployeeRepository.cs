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
        IEnumerable<Employee> GetEmployees();
        List<String> GetPosition();
        Employee GetEmployeeByID(int id);

        void AddNew(Employee employee);

        void Update(Employee employee);
    }
}
