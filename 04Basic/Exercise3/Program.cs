using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool succes = false;
            int i = 0;
            string hello = "Hello from SEDC Codecademy 2021";
            do
            {
                Console.WriteLine($"Enter a number between 0 and {hello.Length}");
                string input = Console.ReadLine();
            
                     int.TryParse(input, out i);
                if (i < hello.Length)
                {
                    succes = true;
                }
               

            } while (!succes);

            Console.WriteLine(Substrings(hello, i));

        }
        static string Substrings(string str , int a)
        {
            char[] array = str.ToCharArray();
            char[] newArray = new char[a];
            for(int i = 0; i < a-1; i++)
            {
                newArray[i] = array[i];
            }
            string converted = new string(newArray);
            return converted;
        }
    }
}
