using System;

namespace Bonus1Second_smallest_number
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create new console application “Second smallest number” that takes numbers as input, as many as the user likes, find and print the second smallest number.
            int[] numbers = new int[4];
            int num;
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("Please Enter A Number");
                bool number = int.TryParse(Console.ReadLine(), out num);
                if (number)
                {
                    numbers[i] = num;
                } else { i--; }
            }
            int lowest = int.MaxValue;
            int secondLowest = int.MaxValue;
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] < lowest)
                {
                    secondLowest = lowest;
                    lowest = numbers[i];
                } else if (numbers[i] < secondLowest)
                {
                    secondLowest = numbers[i];
                }
            }
            
            Console.WriteLine("second lowest is " + secondLowest);
           


        }
    }
}
