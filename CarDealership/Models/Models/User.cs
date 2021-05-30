using CarDealership.Domain.Enum;
using CarDealership.Domain.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Domain.Models
{
    public class User : BaseEntity , IUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public UserType Type { get; set; }

        public string Password { get; private set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public User()
        {

        }
        public User(string firstName, string lastName, int age, string username, string password, string email, UserType type)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Type = type;
            Username = username;
            Password = password;
            Email = email;
            Random rnd = new Random();
            Id = rnd.Next(100, 1000);
        }


        public bool CheckPassword(string password)
        {
            return Password == password;
        }

        public User LogIn(string username, string password)
        {
            if (Username.ToLower() != username.ToLower()) return null;

            if (!CheckPassword(password))
            {

                throw new Exception("Wrong Password");
            }

            return this;


        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

        public UserType StoreStatus()
        {   
            return Type;
        }

        public override string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
