using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class DogShelter
    {
        public static List<Dog> Dogs { get; set; }

        static DogShelter()
        {
            Dogs = new List<Dog>();
          


        }

        public static void PrintAll()
        {
           
                foreach (Dog dog in Dogs)
                {
                try
                {
                    if (Dog.Validate(dog))
                    {
                        Console.WriteLine(dog.Info());
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
       
           
        }
    }
}
