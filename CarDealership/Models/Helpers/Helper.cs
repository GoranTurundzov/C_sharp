using CarDealership.Domain.Database;
using CarDealership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealership.Domain.Helpers
{
    public static class Helper
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }

        }
        public static string PasswordValidation()
        {
            while (true)
            {
                Console.WriteLine("Enter password (Must be at least 6 characters long and contain at least 1 number");
                string password = Console.ReadLine();
                bool contains = false;
                char[] pass = password.ToCharArray();
                foreach (char a in pass)
                {
                    if (int.TryParse(a.ToString(), out int number))
                    {
                        contains = true;
                    }
                }
                if (password.Length > 5 && contains)
                {
                    return password;
                }
                Console.WriteLine("Password Must be at least 6 characters long and contain at least 1 number");



            }

        }
        public static string ConfirmPassword()
        {
            while (true)
            {

                string pass1 = PasswordValidation();
                Console.WriteLine("Confirm password");
                string pass2 = Console.ReadLine();
                if (pass1 == pass2)
                {
                    return pass1;
                }
                else
                {
                    Console.WriteLine("Passwords did not match");

                }
            }

        }
        public static string setUsernameNewUser(List<User> users)
        {
            while (true)
            {
                bool found = false;
                string username = Console.ReadLine();
                foreach (User account in users)
                {
                    if (account.Username == username.ToLower())
                    {
                        Console.WriteLine("Username alreay exist");
                        Console.WriteLine("Enter new Username");
                        found = true;
                    }

                }
                if (found)
                {
                    continue;
                }
                return username;

            }
        }

        public static void SlowPrint(string txt)
        {
            string text = txt;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        public static void JoinData()
        {
            
            ShopDB.Users.AddRange(ShopDB.Managers);
            ShopDB.Users.AddRange(ShopDB.Supplyers);
            ShopDB.Users.AddRange(ShopDB.Costumers);
            JoinVehicles();
           
        }

        public static void JoinVehicles()
        {
            ShopDB.Vehicles.Clear();
            ShopDB.Vehicles = ShopDB.Vehicles.Concat(ShopDB.Automobiles).Concat(ShopDB.Vans).Concat(ShopDB.Trucks).ToList();
        }

        public static void AddFunds(Costumer costumer)
        {
            Console.WriteLine("How much would you like to add");
            int sum = 0;
            if(int.TryParse(Console.ReadLine(), out sum))
            {
                costumer.Balance += sum;
                Console.WriteLine($"{sum} succesfully added to {costumer.FirstName}'s account");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }


    }
}
