using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter A number");
            string firstNumber = Console.ReadLine();
            Console.WriteLine("Enter A number");
            string secondNumber = Console.ReadLine();
            Console.WriteLine("Enter A number");
            string thirdNumber = Console.ReadLine();
            Console.WriteLine("Enter A number");
            string fourthNumber = Console.ReadLine();
            Console.WriteLine("Enter A number");

            bool converted1 = int.TryParse(firstNumber, out int number1);
            bool converted2 = int.TryParse(secondNumber, out int number2);
            bool converted3 = int.TryParse(thirdNumber, out int number3);
            bool converted4 = int.TryParse(fourthNumber, out int number4);

            if(converted1 && converted2 && converted3 && converted4)
            {
                Console.WriteLine("the average summ of thoese number is " + ((number1 + number2 + number3 + number4) / 4));
            }
            else
            {
                Console.WriteLine("Enter Numbers please");
            }

        }
    }
}
