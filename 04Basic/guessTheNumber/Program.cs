using System;

namespace guessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------HELLO AND WELCOME TO GUESS THE NUMBER!---------------------");
            Console.WriteLine("----------------------------RULES:-------------------------------------");
            Console.WriteLine("--Each contester gets 50 attemps to guess the random generated numbers --");
            Console.WriteLine("--all you have to do is enter a number and get a hit in return untill--");
            Console.WriteLine("--------you guessed the number correctly or your attemps run off--------");
            Console.WriteLine("----------------------------GOOD LUCK!!--------------------------------");
          
            Console.WriteLine(" \n  \n ");
            Console.WriteLine("Tips: \n - it's a 3 digit number \n -when you are in a 50 range it tell you that you are close");

            int total = 0;
          
            int[] numbers = { (new Random()).Next(100, 999), (new Random()).Next(100, 999) };  //Go limitirav na 3 cifren za poslena da e igrata
        
            for (int i = 0; i < numbers.Length; i++)
            {
                int attempts = 10;
                Console.WriteLine($"GUESSING NUMBER{i + 1}");

                do
                {
                    Console.WriteLine($"Enter a number (you have {attempts} attempts left)");
                    bool entered = int.TryParse(Console.ReadLine(), out int guessed);
                    if (!entered)
                    {
                        Console.WriteLine("Thats Not A NUMBER!");
                        attempts--;
                    }
                    else {
                    if (guessed == numbers[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"CORRECT!!!!!! you guessed the number with {attempts} attemps left");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else if (guessed < numbers[i] + 51 && guessed > numbers[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("the random number is Lower than the one entered (you are close to the number ) \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        attempts--;
                    }
                    else if (guessed > numbers[i] - 51 && guessed < numbers[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("the random number is Higher than the one entered (you are close to the number ) \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        attempts--;
                    }
                    else if (guessed < numbers[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("the random number is Higher than the one entered \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        attempts--;
                    }
                    else if (guessed > numbers[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("the random number is Lower than the one entered \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        attempts--;
                    }
                    }


                } while (attempts > 0);

                if (attempts == 0)
                {
                    Console.WriteLine($"You have lost and the random number was {numbers[i]}");
                    
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"CONGRRATULATIONS YOU HAVE BEATEN THE LEVEL WITH {attempts} ATTEMPTS LEFT AND WON {attempts * 3} POINTS!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                total += (attempts * 3);
            }
            Console.WriteLine($"{total} total points WON!");
        }
    }
}
