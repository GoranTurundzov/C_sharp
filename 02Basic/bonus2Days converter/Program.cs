using System;

namespace bonus2Days_converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int days;
            bool converted = false;

            do
            {
                Console.WriteLine("Enter Number of days");
                converted = int.TryParse(Console.ReadLine(), out days);
            } while (!converted);
            int years = days / 365;
            int months = (days % 365) / 30;
            int day = (days % 365) % 12;

            Console.WriteLine(days + " days is equal to " + years + " years " + months + " months " + day + " days ");

            
        }
    }
}
