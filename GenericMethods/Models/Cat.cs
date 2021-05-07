using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cat : Pet
    {
        public int LivesLeft { get; set; }

        public bool IsLazy { get; set; }

        public Cat(string name, int age, int livesLeft , bool isLazy ) : base (name , EnumType.Cat , age)
        {
            LivesLeft = livesLeft;
            IsLazy = isLazy;
        }
        public override string GetInfo()
        {
           string asd =  IsLazy ? "IS" : "is NOT";
            return $"The Cat {Name} AGE: {Age} has {LivesLeft} lives left and {asd} lazy";
        }
    }
}
