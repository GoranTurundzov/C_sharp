using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Person
    {
       private string Username { get; set; }

        private string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Admin { get; set; }
        
        public string Pin { get; set; }

        public int FailedLogInAttempts { get; set; } = 0;
        public Person(string firstName, string lastName, string username, string password , bool type , string pin)
        {
            Pin = pin;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Admin = type;
           
    }
        public bool CheckPassword(string password)
        {
            return Password == password;
        }

        public Person LogIn(string username, string password)
        {
            if (Username.ToLower() != username.ToLower()) return null;

            if (!CheckPassword(password)) throw new Exception("Wrong Password");
            if (FailedLogInAttempts >= 3) throw new Exception("Account Locked. Please Contact Goran Turundzov for unlocking it(or turn the program off and on again :D)");
            return this;

        }
        public bool PinCheck(string pin)
        {
           
            
                if (pin != Pin) FailedLogInAttempts++; else { FailedLogInAttempts = 0 ; }
              
          
           
            return Pin == pin;
        }
        public bool Locked()
        {
            if (FailedLogInAttempts > 2)
            {
                Helper.Exiting("Account is BANNED!");
                Console.Clear();
                throw new Exception($"Account {Username} has been locked");
            }

            return FailedLogInAttempts < 3;
        }
        
    }
}
