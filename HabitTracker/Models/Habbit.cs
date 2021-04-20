using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class Habit
    {
        public string HabitName { get; set; }

        public Difficulty Difficulty { get; set; }

        public Group TypeOfHabit { get; set; }

        public DateTime Duration { get; set; } 

        public string Sort { get; set; }

        public int Occurences { get; set; }
        public Habit(string habitName , Difficulty difficulty , Group type ,string sort)
        {
            HabitName = habitName;
            Difficulty = difficulty;
            TypeOfHabit = type;
            Sort = sort;
            Duration = new DateTime();
            Occurences = 0;
        }

        public Habit(string v, Difficulty hard, Group activities_and_Hobbies)
        {
        }

        public void LogHabit(int duration)
        {
            Duration = Duration.AddMinutes(duration);
            Occurences = Occurences + 1;
        }
       
       
    }
}
