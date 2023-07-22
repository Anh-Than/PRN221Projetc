using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_PT5
{
    public delegate void ActionDelegate(string msg);
    public class Class_Show
    {
        public static void Show(string msg) => Console.WriteLine(msg);
    }
    public class Class_Event
    {
        public event ActionDelegate AttackEvent;
        public event ActionDelegate DefenseEvent;
        public void Register_AttackEvent()
        {
            AttackEvent += new ActionDelegate(Class_Show.Show);
        }
        public void Register_DefenseEvent()
        {
            DefenseEvent += new ActionDelegate(Class_Show.Show);
        }
        public void Raising_AttackEvent()
        {
            AttackEvent("Attack!");
        }
        public void Raising_DefenseEvent()
        {
            DefenseEvent("Defense!");
        }

    }
    class Club<T> : IEnumerable<T> where T : IPlayer
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void Add(T t)
        {
            //Add Player

            //
            Class_Event ce = new Class_Event();
            float average = (t.speed + t.power + t.attack + t.stamina + t.defense) / 5;
            if (average > 80)
            {            
                ce.Register_AttackEvent();
            }
            if(average > 60 && average < 80)
            {
                ce.Register_DefenseEvent();
            }
        }
    }
    public class Player : IPlayer
    {
        private string _name;
        private int _age;
        private int _attack;
        private int _defense;
        private int _stamina;
        private int _speed;
        private int _power;
        public string name { get => _name; set => _name = value; }
        public int age { get => _age; set => _age = value; }
        public int attack { get => _attack; set => _attack = value; }
        public int defense { get => _defense; set => _defense = value; }
        public int stamina { get => _stamina; set => _stamina = value; }
        public int speed { get => _speed; set => _speed = value; }
        public int power { get => _power; set => _power = value; }

        public void GetInfo()
        {
            Console.WriteLine($"{_name}, {_age}, average point of player: " + (_attack + _defense + _stamina + _speed + _power));
        }         
    }
}
