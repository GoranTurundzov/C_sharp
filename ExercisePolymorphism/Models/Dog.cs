using System;

namespace Models
{
    public class Dog
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public int ID { get; set; } = -1;

        public Dog()
        {

        }
        public Dog(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public Dog(string color , int id)
        {
            ID = id;
            Color = color;
        }
        public Dog(int id, string name , string color )
        {
            ID = id;
            Name = name;
            Color = color;
        }

        public string Bark()
        {
            return "Bark bark";
        }
        public string Info()
        {
            return $"{ID} : {Name} , {Color}  {Bark()}";
        }
        public static bool Validate(Dog dog)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            bool complete = true;
            if (dog.Name == null || dog.ID < 0 || dog.Color == null)
            {
                complete = false;
                Console.WriteLine("Dog incomplete");
            }

            if (dog.ID < 0)
            {
               complete = false;
               Console.WriteLine("ID below 0");
            }
            if(dog.Name == null)
            {
                Console.WriteLine("a Dog has no name");
                complete = false;
            }
            else if (dog.Name.Length < 2 )
            {
             complete = false;
            Console.WriteLine("Name is too short");
            }

            Console.ForegroundColor = ConsoleColor.White;
            return complete;
        }
    }
}
