using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine.Classes
{
    class User
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Balance { get; set; } = 10000;

        private int PIN { get; set; }

        private long CardNumber { get; set; }

        public User(string name , string lastName)
        {
            Name = name;
            LastName = lastName;
        }
        public void SetPin(int num)
        {
            PIN = num;
           
        }

        public void SetCardNumber(long num)
        {
            CardNumber = num;
            
        }

        public string ShowInfo()
        {
            return $"User {LastName} {Name}  \n  Card: {CardNumber.ToString("####-####-####-####")} ({PIN.ToString("0000")}) \n Balance: {Balance.ToString("C", new CultureInfo("en-US"))}";
        } 
        public long GetCardNumber()
        {
            return CardNumber;
        }

        public int GetPinNumber()
        {
            return PIN;
        } 
        public int Witdraw(int sum)
        {
            return Balance -= sum;
        }
    }
}
