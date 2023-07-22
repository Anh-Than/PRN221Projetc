using Library.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class EmployeeDBContext :BaseDAL
    {
        private static EmployeeDBContext instance = null;
        private static readonly object instanceLock = new object();
        private EmployeeDBContext() { }
        public static EmployeeDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeDBContext();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Employee> GetEmployeeList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select e.Id, e.Name, Dob, Sex, Position, Department, d.Name " +
                "from Employee e inner join Department d " +
                "on e.Department = d.Id";
            var employees = new List<Employee>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeId = dataReader.GetInt32(0),
                        EmployeeName = dataReader.GetString(1),
                        EmployeeDob = dataReader.GetDateTime(2),
                        EmployeeSex = dataReader.GetString(3),
                        EmployeePosition = dataReader.GetString(4),
                        EmployeeDepartment = dataReader.GetInt32(5),
                        EmployeeDepartmentName = dataReader.GetString(6)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return employees;
        }

        public IEnumerable<Department> GetDepartments()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select Id, Name from Department";
            var depts = new List<Department>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    depts.Add(new Department
                    {
                        DeptId = dataReader.GetInt32(0),
                        DeptName = dataReader.GetString(1),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return depts;
        }

        public List<string> GetPositions()
        {
            IDataReader dataReader = null;
            string SQLSelect = "select distinct Position from Employee";
            List<String> positions = new List<String>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    positions.Add(dataReader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return positions;
        }
    }
}
