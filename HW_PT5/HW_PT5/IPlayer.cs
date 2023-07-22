using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_PT5
{
    public interface IPlayer
    {
        public string name { get; set; }
        public int age { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int stamina { get; set; }
        public int speed { get; set; }
        public int power { get; set; }

        public void GetInfo();
    }
}
