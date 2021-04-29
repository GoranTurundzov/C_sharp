using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class DataBase
    {
        public static List<Person> Users { get; set; }


        static DataBase()
        {
            Users = new List<Person>
            {
                new Admin("BEG",  "BEG", "test123", EnumCompany.BEG),
                 new Admin("EVN", "EVN", "test123", EnumCompany.EVN),
                 new Admin("VODOVOD", "vodovod", "test123", EnumCompany.Vodovod),
                 new Admin("Komunalec", "gorann", "test123", EnumCompany.BEG)
        };
        }

        public static Person LogIn(string username , string password)
        {
            Person user = Users.Where(x => x.LogIn(username, password) != null).FirstOrDefault();
            if (user == null) throw new Exception("Invalid Username/Password");
            return user;
        }

        
        
    }
}
