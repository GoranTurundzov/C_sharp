using System;

namespace Exercise06
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[0];
            int count = 0;
            
            while (true)
            {
                Console.WriteLine("Would you like to enter a name press any key ");
                Console.WriteLine("if you want to print the array so far press `Y`");
                string input = Console.ReadLine();
                
                if (input != "y" || input != "y")
                {
                    Array.Resize(ref names, count + 1 );
                    Console.WriteLine("Enter new Name");
                    names[count] = Console.ReadLine();
                    count++;
                }
                else
                {
                   
                    Console.WriteLine("Array Length: " + names.Length);
                    foreach(string name in names)
                    {
                        Console.WriteLine(name);
                    }
                    break;
                }
            }
        }
    }
}
