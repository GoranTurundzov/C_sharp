using CarDealership.Domain.Enum;
using CarDealership.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Domain.Models
{
    public class Manager : User , IManager

    {
        public Manager()
        {
            Type = UserType.Manager;
        }

        public int YearsExperience { get; set; }
       public Manager (string firstName, string lastName, int age, string email, string username, string password , int yearsExp) : base(firstName, lastName, age, username, password, email, UserType.Manager)
            {
            YearsExperience = yearsExp;
            }


      

            public override string GetInfo()
        {
            return $"{FirstName} {LastName} - {Type}";
        }
    }
}
