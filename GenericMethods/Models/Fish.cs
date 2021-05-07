using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Fish : Pet
    {
        public string Color { get; set; }

        public string Size { get; set; }

        public Fish(string name , int age, string color , string size) : base (name, EnumType.Fish, age)
        {
            Color = color;
            Size = size;
        }

        public override string GetInfo()
        {
            return $"The fish {Name} is {Size}, {Color} and is {Age} old";
        }

       
    }
}
