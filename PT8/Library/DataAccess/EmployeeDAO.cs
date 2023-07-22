using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance = null;
        private static readonly object instanceLock = new object();
        public static EmployeeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            var employees = new List<Employee>();
            try
            {
                using var context = new PeFall21B5Context();
                employees = context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employees;
        }

        public Employee GetEmployeeByID(int id)
        {
            Employee emp = null;
            try
            {
                using var context = new PeFall21B5Context();
                emp = context.Employees.SingleOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return emp;
        }

        public void AddNew(Employee employee)
        {
            try
            {
                Employee _emp = GetEmployeeByID(employee.Id);
                if (_emp == null)
                {
                    using var context = new PeFall21B5Context();
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Employee is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Employee employee)
        {
            try
            {
                Employee _emp = GetEmployeeByID(employee.Id);
                if (_emp != null)
                {
                    using var context = new PeFall21B5Context();
                    context.Employees.Update(employee);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Employee does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<String> GetPositions()
        {
            List<String> positions = new List<String>();
            var employees = GetEmployeeList();
            try
            {
                foreach (Employee employee in employees)
                {
                    if (!positions.Contains(employee.Position.ToString()))
                    {
                        positions.Add(employee.Position);
                    }
                }
                return positions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
