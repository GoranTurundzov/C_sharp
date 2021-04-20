using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GoodHabit : Habit
    {

        public GoodHabit(string habitName , Group type , Difficulty difficulty) : base (habitName , difficulty , type , "GoodHabit")
        {

        }
    }
}
