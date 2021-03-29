using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make 2 arrays called studentsG1 and studentsG2 and fill them with 5 student names.
           // Get a number from the console between 1 and 2 and print the students from that group in the console.
           // Ex: studentsG1["Zdravko", "Petko", "Stanko", "Branko", "Trajko"]
           string[] G1 = new string[]{ "Goran", "Zoran", "Filip" , "Slave", "Aco"};
           string[] G2 = new string[] { "Petar", "Andrej", "Ana", "Marija", "Vesna" };
            bool breaks = false;
            while (!breaks)
            {
                Console.WriteLine("Please Enter `1` or `2` to print the group");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("G1 Students are:");
                        foreach (string student in G1)
                        {
                            Console.WriteLine(student);
                        }
                        breaks = true;
                        break;
                    case "2":
                        Console.WriteLine("G2 Students are:");
                        foreach (string student in G2)
                        {
                            Console.WriteLine(student);
                        }
                        breaks = true;
                        break;
                    default:
                        Console.WriteLine("Error: 1 or 2 not entered!!");
                        break;

                }
            }
           
        }
    }
}
