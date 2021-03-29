using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make a console application called SumOfEven.
            //Inside it create an array of 6 integers.
            //Get numbers from the input, find and print the sum of the even numbers from the array:
            int[] numbers = new int[6];
            for(int i = 1; i <= numbers.Length; i++)
            {
                int num;
                Console.WriteLine("Enter number " + i);
                bool converted = int.TryParse(Console.ReadLine(), out num);
                if (converted)
                {
                    numbers[i - 1] = num;
                } else
                {
                    i--;
                }

            }

            int result = 0;
            foreach(int num in numbers)
            {
                
                if (num % 2 == 0)
                {
                    
                    result += num;
                }
            }
            Console.WriteLine("The result of all Even numbers is " + result);


        }
    }
}
