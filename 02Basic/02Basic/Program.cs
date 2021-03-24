using System;

namespace _02Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            string number1 = Console.ReadLine();
            string number2 = Console.ReadLine();

            bool convert1 = int.TryParse(number1, out int numberOne);
            bool convert2 = int.TryParse(number2, out int numberTwo);

            if (convert1 && convert2)
            {
                if (numberOne < numberTwo)
                {
                    if (numberTwo % 2 == 0)
                    {
                        Console.WriteLine(numberTwo + "is bigger and its Even");
                    }
                    else
                    {
                        Console.WriteLine(numberTwo + "is bigger and its Odd");
                    }
                }
                else if (numberOne == numberTwo)
                {
                    if (numberOne % 2 == 0)
                    {
                        Console.WriteLine(numberOne + "and" + numberTwo + "are equal and are Even");
                    }
                    else
                    {
                        Console.WriteLine(numberOne + "and" + numberTwo + "are equal and are Odd");
                    }
                }
                else
                {
                    if (numberOne % 2 == 0)
                    {
                        Console.WriteLine(numberOne + "is bigger and its Even");
                    }
                    else
                    {
                        Console.WriteLine(numberOne + "is bigger and its Odd");
                    }
                }


            }

        }
    }
}
