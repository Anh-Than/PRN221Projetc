using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_PT4
{
    public class Movie : IMovie
    {
        private int _id;
        private string _name;
        private DateTime _publishDate;
        private string _director;
        private string _subtitle;
        private float _averageRate;
        public int ID { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public DateTime PublishDate { get => _publishDate; set => _publishDate = value; }
        public string Director { get => _director; set => _director = value; }
        public string Subtitle { get => _subtitle; set => _subtitle = value; }
        public float AverageRate { get => _averageRate; set => _averageRate = value; }

        public void Display()
        {
            Console.WriteLine($"{_name},{_publishDate},{_director},{_averageRate}");
        }
        private double[] RateList = new double[3];
        public double this[int i]
        {
            get => RateList[i]; 
            set => RateList[i] = value;
        }
        public double Calculate()
        {
            return _averageRate = (float) (RateList[0] + RateList[1] + RateList[2])/3;
        }
    }
}
