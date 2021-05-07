using System;

namespace Models
{
    public abstract class Pet
    {
        public  string Name { get; set; }

        public  EnumType Type { get; set; }

        public int Age { get; set; }

        public  Pet(string name , EnumType type , int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }

        public abstract string GetInfo();

        public string MyName()
        {
            return $"{Name}";
        }

    }
}
