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

        public Person(string firstName, string lastName, string username, string password , bool type)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }
        public bool CheckPassword(string password)
        {
            return Password == password;
        }

        public Person LogIn(string username, string password)
        {
            if (Username.ToLower() != username.ToLower()) return null;

            if (!CheckPassword(password)) throw new Exception("Wrong Password");

            return this;

        }
    }
}
