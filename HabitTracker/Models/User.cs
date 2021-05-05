using System;
using System.Collections.Generic;
using System.Linq;
namespace Models
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public List<Habit> Habits { get; set; }

        private string Pin { get; set; }
        
        public User(string username , string password , string email , string pin)
        {
            Username = username;
            Password = password;
            Email = email;
            Habits = new List<Habit>();
            Pin = pin;
        }

        public void AddHabit(Habit habit)
        {
            Habits.Add(habit);
        }

        public void RemoveHabit(Habit habit)
        {
            Habits.Remove(habit);
        }


        public string GetInfo()
        {
            return $"User {Username} ({Email}). {Habits.Count} Habits Logged";
        }
        public string ListHabits()
        {
            string habits = "Habits: \n";
            for(int i = 1; i <= Habits.Count; i++)
            {
                habits += $"{i}.{Habits[i-1].HabitName} \n";
            }
            return habits;

        }
        public void DeleteHabit(int input)
        {
            Habits.RemoveAt(input - 1);
        }
        public string Stats()
        {
            string stats = $"Stats: \n{"Habit",20} | {"Occurences",10} | {"Duration",6} | {"Type",20} | {"KIND", 5}  \n";
            foreach (Habit habit in Habits)
            {
                
                stats += $"{habit.HabitName,20} | {habit.Occurences,-10} |  {habit.Duration.ToString("H:mm:ss"),6} | {habit.TypeOfHabit,20} | {habit.Sort} \n";
                Console.ForegroundColor = ConsoleColor.White;
            }




            return stats;
        }
        public bool ValidPassword(string password)
        {
           
            return password == Password;
        }

        public User LogIn(string username, string password)
        {
            if (Username.ToLower() != username.ToLower()) return null;


            if (Password != password)
            {
             
                throw new Exception("Wrong Password");
            }
         
            return this;

        }

        public bool CheckPin(string pin)
        {
            return pin == Pin;
        }

    }
}
