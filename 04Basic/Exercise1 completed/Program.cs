using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool converted1 = false;
            bool oper = false;
            string operators;
            bool converted2 = false;
            int num1;
            int num2;
            do
            {
                do
                {
                    Console.WriteLine("Enter number 1");
                    converted1 = int.TryParse(Console.ReadLine(), out num1);
                }
                while (!converted1);

                do
                {
                    Console.WriteLine("Select + , - , / , *");
                    operators = Console.ReadLine();
                    if (operators == "-" || operators == "+" || operators == "/" || operators == "*")
                    {
                        oper = true;
                    }
                } while (!oper);

                do
                {
                    Console.WriteLine("Enter number 2");
                    converted2 = int.TryParse(Console.ReadLine(), out num2);
                }
                while (!converted2);

                if (operators == "+")
                {
                    Console.WriteLine(Sum(num1, num2));
                }
                else if (operators == "-")
                {
                    Console.WriteLine(Subrtract(num1, num2));
                }
                else if (operators == "/")
                {
                    Console.WriteLine(divide(num1, num2));
                }
                else if (operators == "*")
                {
                    Console.WriteLine(multiply(num1, num2));
                }
                Console.WriteLine("If u want to calculate something else press \"Y\"");
            } while (Console.ReadLine().ToLower() == "y");
        }


        static int Sum(int num1, int num2)
        {
            int sum = num1 + num2;
            return sum;
        }

        static int Subrtract(int num1, int num2)
        {
            return num1 - num2;
        }
        static decimal divide(int a, int b)
        {
            decimal c = Convert.ToDecimal(b);
            return a / c;
        }
        static int multiply(int a, int b)
        {
            return a * b;
        }
    }
}
