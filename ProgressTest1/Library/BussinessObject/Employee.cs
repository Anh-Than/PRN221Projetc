using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BussinessObject
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeDob { get; set; }
        public string EmployeeSex { get; set; }
        public string EmployeePosition { get; set; }
        public int EmployeeDepartment { get; set; }
        public string EmployeeDepartmentName { get; set; }
    }
}
