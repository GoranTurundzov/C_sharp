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
                new Admin("BEG",  "BEG", "test123", EnumCompany.BEG , "1234"),
                 new Admin("EVN", "EVN", "test123", EnumCompany.EVN , "1234"),
                 new Admin("VODOVOD", "vodovod", "test123", EnumCompany.Vodovod , "1234"),

                 new Admin("Komunalec", "gorann", "test123", EnumCompany.BEG , "123")
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
