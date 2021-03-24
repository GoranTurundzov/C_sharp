using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            bool converted1 = int.TryParse(firstNumber, out int number1);
            bool converted2 = int.TryParse(secondNumber, out int number2);


            if(converted1 && converted2)
            {
                Console.WriteLine("first number is " + number1);
                Console.WriteLine("second number is: " + number2);
            }
            else
            {
                Console.WriteLine("Enter Valid Numbers");
            }
            number1 = number1 * number2;
            number2 = number1 / number2;
            number1 = number1 / number2;

            Console.WriteLine("After Swapping : first number is: " + number1);
            Console.WriteLine("After Swapping : second number is: " + number2);


            




        }
    }
}
