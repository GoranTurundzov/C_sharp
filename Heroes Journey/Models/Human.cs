using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Human : Character
    {

       public Human(string charName, Class charClass) : base(charName, 80 , 5 , 4 , charClass , "Human")
        {

        }
    }
}
