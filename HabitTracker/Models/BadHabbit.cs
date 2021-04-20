using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BadHabit : Habit
    {

        public BadHabit(string habitName, Group type, Difficulty difficulty) : base(habitName, difficulty, type, "BadHabit")
        {

        }
    }
}
