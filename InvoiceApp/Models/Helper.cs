using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Models
{
    public static class Helper
    {
        public static List<Invoice> ClearPayed(List<Invoice> list)
        {
            List<Invoice> newList = list.Where(x => !x.Payed).ToList();
            return newList;
        }

        public static void PressToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void Validate(Person person)
        {
            while (true)
            {
             
                Console.WriteLine("Enter your pin");
                if (person.PinCheck(Console.ReadLine())) { break; } else
                {
                    person.Locked();
                    Console.WriteLine("Wrong Pin");
                }
            }
           
          

        }

        public static void Exiting(string txt)
        {
            string text = txt;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }

    }
}
