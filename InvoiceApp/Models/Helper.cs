using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
