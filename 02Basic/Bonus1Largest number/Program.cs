using System;

namespace Bonus1Largest_number
{
    class Program
    {
        static void Main(string[] args)
        {

            // Bonus 1: Create new console application “Largest number” that takes four numbers as input to calculate and print the largest.

            int num1;
            int num2;
            int num3;
            int num4;
            int lowest;
            bool convert2 = false;
            bool convert3 = false;
            bool convert4 = false;
            Console.WriteLine("Enter the 1st number");
            bool convert1 = int.TryParse(Console.ReadLine(), out num1);
            while (!convert1)
            {
                Console.WriteLine("Enter the 1st number");
                convert1 = int.TryParse(Console.ReadLine(), out num1);
            }

            lowest = num1;
             
            do
                {
                    Console.WriteLine("Enter 2nd number ");
                    convert2= int.TryParse(Console.ReadLine(), out num2 );
            } while (!convert2) ;
             
            if(num2 < lowest)
            {
                lowest = num2;
            }
           
            do
            {
                Console.WriteLine("Enter 3rd number ");
                convert3 = int.TryParse(Console.ReadLine(), out num3);
            } while (!convert3);

            if (num3 < lowest)
            {
                lowest = num3;
            }



            do
            {
                Console.WriteLine("Enter 4th number ");
                convert4 = int.TryParse(Console.ReadLine(), out num4);
            } while (!convert4);

            if (num4 < lowest)
            {
                lowest = num4;
            }


            Console.WriteLine("Smallest out of " + num1 + ", " + num2 + ", " + num3 + ", " + num4 + " is: " + lowest);







        }
    }
}
