using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Number");
            string numberOne = Console.ReadLine();
            Console.Write("Enter an operator");
            string operation = Console.ReadLine();
            Console.WriteLine("Enter the second number");
            string numberTwo = Console.ReadLine();

            bool converted1 = int.TryParse(numberOne, out int number1);
            bool converted2 = int.TryParse(numberTwo, out int number2);

            if(converted1 && converted2)
            {
                switch (operation){
                    case "+":
                        Console.WriteLine(number1 + number2);
                        break;
                    case "-":
                        Console.WriteLine(number1 - number2);
                        break;
                    case "*":
                        Console.WriteLine(number1 * number2);
                        break;
                    case "/":
                        Console.WriteLine(number1 / number2);
                        break;
                    default:
                        Console.WriteLine("enter a valid operator");
                        break;
                    
                } 
            }
            else
            {
                Console.WriteLine("enter numbers and operator please");
            }

        }
    }
}
