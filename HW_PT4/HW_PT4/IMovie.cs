using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_PT4
{
    public interface IMovie
    {
        int ID { get; set; }
        string Name { get; set; }
        DateTime PublishDate { get; set; }
        string Director { get; set; }
        string Subtitle { get; set; }
        readonly float AverageRate { get; set; }
        void Display();
    }
}
