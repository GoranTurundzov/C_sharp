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
    public class Costumer : User , ICostumer
    {
        public int Balance { get; set; }
       
        
        public Costumer()
        {
           
           
            Type = UserType.Buyer;
        }
        public Costumer(string firstName , string lastName , int age ,string email, string username , string password ,int balance ) : base(firstName , lastName , age ,username , password , email, UserType.Buyer)
        {
            Balance = balance;

        }
        
        public override string GetInfo()
        {
            return $"{FirstName} {LastName} : Balance {Balance.ToString("C", new CultureInfo("en-GB"))}";
        }
    }
}
