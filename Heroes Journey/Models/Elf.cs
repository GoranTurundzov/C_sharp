using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Elf : Character
    {

        public Elf(string charName, Class charClass) : base(charName, 60 , 4 , 6 , charClass , "Elf")
        {

        }
    }
}
