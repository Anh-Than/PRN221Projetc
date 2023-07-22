using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_PT4
{
    public class CustomList : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private ArrayList MovieList= new ArrayList();
        public void Add(IMovie movie)
        {
            MovieList.Add(movie);
        }
        public void Remove(IMovie movie)
        {
            MovieList.Remove(movie);
        }
        public void Sort(IComparer comp)
        {
            MovieList.Sort(comp);
        }
    }
}
