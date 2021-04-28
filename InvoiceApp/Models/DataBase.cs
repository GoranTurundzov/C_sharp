using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class DataBase
    {
        public static List<Person> Users { get; set; } = new List<Person>();


        static DataBase()
        {

        }

        public static Person LogIn(string username , string password)
        {
            Person user = Users.Where(x => x.LogIn(username, password) != null).FirstOrDefault();
            if (user == null) throw new Exception("Invalid Username/Password");
            return user;
        }
        
    }
}
