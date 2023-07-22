using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class DAO
    {
        //Singleton
        private static DAO instance = null;
        private static readonly object instanceLock = new object();
        public static DAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DAO();
                    }
                    return instance;
                }
            }
        }
        //------------------------------------------------------------
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

        public void Delete(int id)
        {
            try
            {
                Employee emp = GetEmployeeByID(id);
                if(emp != null)
                {
                    using var context = new PeFall21B5Context();
                    context.Employees.Remove(emp);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The employee does not exist");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
