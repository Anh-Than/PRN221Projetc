using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class Repository : IRepository
    {
        public IEnumerable<Project> getProjectList() => DAO.Instance.GetProjectList();

        public List<string> getTypes() => DAO.Instance.GetTypeList();
    }
}
