using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Models
{
    public  class PetStore<T> where T : Pet
    {

       private List<T> list;


        public PetStore()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public string PrintPets()
        {
            string store = $"Pets in {typeof(T).Name} Store: \n";
            foreach(T item in list)
            {
                store += $"{item.GetInfo()} \n";
            }
            return store;
        }

        public void BuyPet(string name)
        {
            T pet = list.FirstOrDefault(x => name == x.Name);
            if (pet == null) Console.WriteLine("There is no pet with that name");
            else
            {
                list.Remove(pet);
                Console.WriteLine($"The {pet.GetType().Name} {name} is now yours. Take good care of it");
                Console.WriteLine($"Come back to the {typeof(T).Name} Store");
            }
            
        }

        
    }
}
