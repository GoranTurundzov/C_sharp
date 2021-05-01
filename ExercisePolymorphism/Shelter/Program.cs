using System;
using Models;
using System.Collections.Generic;
namespace Shelter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog woofie = new Dog("Black" , 4);
            Dog afaf = new Dog(5, "T");
            Dog milo = new Dog(7, "Milo", "White-Brown");
            List<Dog> DogsToBeSheltered = new List<Dog>
            {
                woofie,
                afaf,
                milo,
                new Dog(1 , "Lucky" , "Black"),
                new Dog(2, "Spike" , "Brown"),
                new Dog(3 , "Smiley" , "Brown-ish"),
                new Dog(4 , "Toby" , "White"),
                new Dog(5, "Bobby" )
            };
            foreach(Dog dog in DogsToBeSheltered)
            {
                if (Dog.Validate(dog))
                {
                    Console.WriteLine($"{dog.Name} is now sheltered and waiting to be adopted");
                    DogShelter.Dogs.Add(dog);
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Please fill all information about the dog in order to shelter it");
                    Console.ForegroundColor = ConsoleColor.White;
                }
             
                
            }


            Console.WriteLine("Please enter any key to see the dogs in the shelter");
            Console.ReadKey();
            DogShelter.PrintAll();


        }
    }
}
