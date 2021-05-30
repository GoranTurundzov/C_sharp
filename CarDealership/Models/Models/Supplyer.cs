using CarDealership.Domain.Enum;
using CarDealership.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Domain.Models
{
    public class Supplyer : User , ISupplyer
    {

        public int Salary { get; set; }

        public Supplyer()
        {
            Type = UserType.Supplyer;
        }
        public Supplyer(string firstName, string lastName, int age, string email, string username, string password) : base(firstName, lastName, age, username, password, email, UserType.Supplyer)
        {
            Salary = 1000;
        }

        public override string GetInfo()
        {
            return $"{FirstName} {LastName} : {Type} ({Salary.ToString("C", new CultureInfo("en-GB"))})";
        }

        public string RaiseSalary(Manager manager , int rise)
        {
            Salary += rise;
            return $"Salary of {FirstName} risen for {rise} by {manager.FirstName} {manager.LastName}";

        }
        public string LowerSalary(Manager manager, int rise)
        {
            Salary -= rise;
            return $"Salary of {FirstName} lowered for {rise.ToString("C", new CultureInfo("en-GB"))} by {manager.FirstName} {manager.LastName}";
        }
    }
}
