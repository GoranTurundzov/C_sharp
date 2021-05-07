using System;
using Models;

namespace GenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Data
            Cat garf = new Cat("Garfield", 8, 3, true);
            Cat tom = new Cat("Tom", 11, 1, false);
            Dog toby = new Dog("Toby", 5, true, "PorkRibs");
            Dog spike = new Dog("Spike", 11, false, "Flesh");
            Fish goldie = new Fish("Goldie", 5, "golden", "XXL");
            Fish carp = new Fish("Carp", 3, "black", "Mediym");
            PetStore<Pet> milenici = new PetStore<Pet>();
            milenici.Add(garf); milenici.Add(tom); milenici.Add(toby); milenici.Add(spike); milenici.Add(goldie); milenici.Add(carp);
            PetStore<Fish> fishes = new PetStore<Fish>();
            fishes.Add(goldie); fishes.Add(carp);
            PetStore<Dog> doggies = new PetStore<Dog>();
            doggies.Add(toby); doggies.Add(spike);
            PetStore<Cat> catz = new PetStore<Cat>();
            catz.Add(garf); catz.Add(tom);
            #endregion



            Console.WriteLine(milenici.PrintPets());
            Console.WriteLine("\n \n");
            Console.WriteLine(fishes.PrintPets());
            Console.WriteLine("\n");
            Console.WriteLine(doggies.PrintPets());
            Console.WriteLine("\n");
            Console.WriteLine(catz.PrintPets());
            Console.WriteLine("\n");
            milenici.BuyPet("Carp");
            catz.BuyPet("Tom");

           Console.WriteLine(milenici.PrintPets());


        }
    }
}

