using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IRepository
    {
        public IEnumerable<Project> getProjectList();
        public List<string> getTypes();
    }
}
