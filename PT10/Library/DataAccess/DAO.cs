using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class DAO
    {
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

        public IEnumerable<Project> GetProjectList()
        {
            var projects = new List<Project>();
            try
            {
                using var context = new PeFall21B5Context();
                projects = context.Projects.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return projects;
        }

        public List<string> GetTypeList()
        {
            List<string> types = new List<string>();
            try
            {
                using var context = new PeFall21B5Context();
                var projects = GetProjectList();
                foreach (var project in projects)
                {
                    if (!types.Contains(project.Type))
                    {
                        types.Add(project.Type);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return types;
        }
    }
}
