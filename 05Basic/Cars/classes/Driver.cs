using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.classes
{
    public class Driver
    {
        public string Name { get; set; }

        public int Skill { get; set; }


        public Driver(string name , int skill)
        {
            Name = name;
            Skill = skill;

        }
    }
}
