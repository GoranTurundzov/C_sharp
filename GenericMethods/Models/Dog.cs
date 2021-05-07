using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Dog : Pet
    {
        public bool IsGoodBoi { get; set; }

        public string FavouriteFood { get; set; }

        public Dog(string name , int age, bool isGoodBoi , string favouriteFood) : base(name, EnumType.Dog, age)
        {
            IsGoodBoi = isGoodBoi;
            FavouriteFood = favouriteFood;
        }

        public override string GetInfo()
        {
            string goodBoi = IsGoodBoi ? "Is A Good BOI" : "IS A GOOD BOI(even tho you have selected he is not)";
            return $"The Dog {Name} Age: {Age} , {goodBoi} and likes {FavouriteFood}  ";
        }
    }
}
