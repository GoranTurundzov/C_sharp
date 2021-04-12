using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
       private string Username { get; set; }

        private string Email { get; set; }
        private string Password { get; set; }

        public Character[] Characters = new Character[0];

        public void SetCredentials(string username ,string email , string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }

        public User()
        {

        }

        public string GetUsername()
        {
            string phrase = $"{Username}";
            return phrase.ToLower();
        }

        public string getEmail()
        {
            string email = $"{Email}";
            return email.ToLower();
        }
        public string getPassword()
        {
            return Password;
        }
       
        public string getInfo()
        {
            return $"{Username} {Email} {Password} ";
        }
        public void CreateCharacter(Character chara)
        {
            Array.Resize(ref Characters, Characters.Length + 1);
                Characters[Characters.Length - 1] = chara;
           
           
        }
        public void listCharacters()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for(int i = 0; i < Characters.Length; i++)
            {
                Console.WriteLine($" {i + 1}.{Characters[i].GetInfo()}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
