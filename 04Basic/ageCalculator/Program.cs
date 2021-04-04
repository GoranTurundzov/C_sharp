using System;

namespace ageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool date = false;

            DateTime dayOfBirth;
            do
            {
                Console.WriteLine("Enter you birthday");
                date = DateTime.TryParse(Console.ReadLine(), out dayOfBirth);
            } while (!date);
            Console.WriteLine(AgeCalculator(dayOfBirth));

        }
        static string AgeCalculator(DateTime birthDay)
        {
         
            
            DateTime today = DateTime.Today;
            int day = today.Day - birthDay.Day;
            int age = today.Year - birthDay.Year;
            int months = today.Month - birthDay.Month;
            if (day < 0)
            {
                 months = today.Month - birthDay.Month - 1;
                day += DateTime.DaysInMonth(today.Year, today.Month);
            }
            if(months < 0)
            {
                age = today.Year - birthDay.Year - 1;
                months += 12;
            }
            
            
            return $" Years {age}  Months{months}  Days{day}";

        }
    }
}
