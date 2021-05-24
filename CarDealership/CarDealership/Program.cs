using CarDealership.Domain.Helpers;
using System;

namespace CarDealership
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserUI.HomeScreen();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
