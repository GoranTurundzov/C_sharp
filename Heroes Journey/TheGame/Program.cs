using System;

using Models;
namespace TheGame
{
    class Program
    {
        static void Main(string[] args)
        {
            #region users;
            User Goran = new User();
            Goran.SetCredentials("Goran","Goran@gmail.com" , "Password");
            Goran.CreateCharacter(new Human("Gazam", Class.Mage));
            Goran.CreateCharacter(new Elf("Stealthy", Class.Rogue));
            User Zoran = new User();
            Zoran.SetCredentials("Zoran", "Zoran@zoran.com", "Pass");
            User[] users = { Goran, Zoran };
            #endregion
            Console.WriteLine("Welcome to Heroes Journey!!!");
            Console.WriteLine();

            while (true)

            {
                Console.WriteLine($" 1.Log In \n 2.Create Account \n 3.Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        LogIn(users);
                        continue;
                    case "2":
                        Console.WriteLine("REGISTER");
                        User newUser = CreateAccount(users);
                        Array.Resize(ref users, users.Length + 1);
                        users[users.Length - 1] = newUser;
                        continue;
                    case "3":
                        Console.WriteLine("EXIT");
                        break;
                    case "admin":
                        foreach(User user in users)
                        {
                            Console.WriteLine(user.getInfo());
                        }
                        break;
                    default:
                        continue;
                }
                break;
            }
            



        }
        static User CreateAccount(User[] users)
        {
            Console.WriteLine("Enter Username!");
            string username = setUsernameNewUser(users);
            string email = setEmailNewUser(users);
            string password = ConfirmPassword();

            User user = new User();
            user.SetCredentials(username,  email , password);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Account {username} created");
            Console.ForegroundColor = ConsoleColor.White;
            return user;
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }

        }
        static string ConfirmPassword()
        {
            while (true)
            {
                Console.WriteLine("Enter password");
                string pass1 = Console.ReadLine();
                Console.WriteLine("Confirm password");
                string pass2 = Console.ReadLine();
                if(pass1 == pass2)
                {
                    return pass1;
                }
                else
                {
                    Console.WriteLine("Passwords did not match");
                }
            }

        }
        static string setEmailNewUser(User[] users)
        {
            while (true)
            {
                bool found = false;
                Console.WriteLine("Enter e-mail");
                string enteredEmail = Console.ReadLine();
                if (IsValidEmail(enteredEmail))
                {
                    foreach (User account in users)
                    {
                        if (enteredEmail.ToLower() == account.getEmail())
                        {
                            Console.WriteLine("Email already exists");
                            found = true;
                        }
                    }
                    if (found) { continue; }
                    return enteredEmail;
                }
                Console.WriteLine("Invalid Email");
                continue;
            }
        }
        static string setUsernameNewUser(User[] users)
        {
            while (true)
            {
                bool found = false;
                string username = Console.ReadLine();
                foreach (User account in users)
                {
                    if (account.GetUsername() == username.ToLower())
                    {
                        Console.WriteLine("Username alreay exist");
                        Console.WriteLine("Enter new Username");
                        found = true;
                    }

                }
                if (found)
                {
                    continue;
                }
                return username;

            }
        }
        static int checkUser(User[] users)
        {
            while (true)
            {

         
            Console.WriteLine("Enter Username;");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            for(int i = 0; i < users.Length; i++)
            {
                if(users[i].GetUsername() == username.ToLower() && users[i].getPassword() == password)
                {
                    return i;
                }
               
             }
                return -1;
            }
        }
        static void LogIn(User[] users)
        {
            int userIndex = checkUser(users);
            if (userIndex < 0)
            {
                Console.WriteLine("Invalid Username/Password");
            }
            else
            {
                Console.WriteLine($"Hello {users[userIndex].GetUsername()}");
                UserUI(users[userIndex]);
            }
        }
        static void UserUI(User user)
        {
            while (true)
            {
                Console.WriteLine($"Select: \n 1.Pick Character \n 2.Create Character \n 3.Log Out");
                switch (Console.ReadLine())
                {
                    case "1":
                        user.listCharacters();
                        Character picked = pickCharacter(user);
                        if (picked.getHealth() > 0)
                        {
                            Console.WriteLine("Event 1");
                            Console.WriteLine("Bandits attack you from nowhere. They seem vey dangerous");
                            picked = gamePlayEvent2(picked , 20);
                        } else
                        {

                            Console.WriteLine("CHaracter is DEAD!");
                            break;
                        }
                            
                        if(picked.getHealth() > 0)
                        {
                            Console.WriteLine("Event 2");
                            Console.WriteLine("You go back to the village");
                            Console.WriteLine("You bump the Guard he attacks");
                            picked = gamePlayEvent2(picked , 30);
                        } else
                        {
                            Console.WriteLine($"Game Over ");
                            break;
                        }
                        if (picked.getHealth() > 0)
                        {
                            Console.WriteLine("Event 3");
                            Console.WriteLine("As you were walking around a land SHARK starts to chase you");
                            picked = gamePlayEvent2(picked , 50);
                        }
                        else
                        {
                            Console.WriteLine($"Game Over ");
                            break;
                        }
                        if (picked.getHealth() > 0)
                        {
                            Console.WriteLine("Event 4");
                            Console.WriteLine("You accidentally step on a rat. His friends are not happy. They attack...");
                            picked = gamePlayEvent2(picked, 10);
                        }
                        else
                        {
                            Console.WriteLine($"Game Over ");
                            break;
                        }
                        if (picked.getHealth() > 0)
                        {
                            Console.WriteLine("Event 5");
                            Console.WriteLine("You find a huge rock. It comes alive somehow and tries to smash you..");
                            picked = gamePlayEvent2(picked, 30);
                        }
                        else
                        {
                            Console.WriteLine($"Game Over ");
                            break;
                        } 
                        if(picked.getHealth() > 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("CONGRATULATIONS YOU HAVE COMPLETED ALL THE CHALLENGES");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Go again?  (press Y to go again)");
                            switch (Console.ReadLine())
                            {
                                case "y":
                                case "Y":
                                    continue;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("GAME OVER");
                        }

                        break;
                    case "2":
                        Character createNew = createNewChar();
                        Console.WriteLine($"Created {createNew.GetInfo()}"); 
                        user.CreateCharacter(createNew);
                        continue;
                    case "3":
                        Console.WriteLine("LogOut");
                        break;
                    default:
                        continue;
                }
                break;
            }
            
        }
        static Character createNewChar()
        {
            while (true)

            {
                Class picked;
                string charName;
                Character newChar;
                Console.WriteLine("Select a Race  \n 1.Human \n 2. Elf \n 3.Dwarf");

                switch (Console.ReadLine())
                {
                    
                    case "1":
                        picked = classSelector();
                        charName = namePicker();
                        newChar = new Human(charName, picked);
                        break;
                    case "2":
                         picked = classSelector();
                        charName = namePicker();
                        newChar = new Elf(charName, picked);
                        break;
                    case "3":
                        picked = classSelector();
                        charName = namePicker();
                        newChar = new Dwarf(charName, picked);
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        continue;


                }
                return newChar;
            }
        }
        static Class classSelector()
        {
            while (true)
            {
                Console.WriteLine("Pick a Class: \n 1.Warrior \n 2.Rogue \n 3.Mage");
                switch (Console.ReadLine())
                {
                    case "1":
                        return Class.Warrior;
                       
                    case "2":
                        return Class.Rogue;
                       
                    case "3":
                        return Class.Mage;
                       
                    default:
                        Console.WriteLine("Invalid input");
                        continue;
                }
                

            }
            
        }
        static string namePicker()
        {
            Console.WriteLine("Choose your character name");
            string name = Console.ReadLine();
            return name;
        }


        static Character pickCharacter(User user)
        {
            int selected = -1;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Pick Character");
                    bool picked = int.TryParse(Console.ReadLine(), out selected);
                    if (picked)
                    {
                        break;
                    }
                }
                if(selected -1 < user.Characters.Length && selected -1 >= 0)
                {
                    return user.Characters[selected - 1];
                }
               

            }
       
        }

        static bool actionPlay()
        {
            while (true)
            {
                Console.WriteLine("Select 1 to Fight or 2 to run and regenerate");
                switch (Console.ReadLine())
                {
                    case "2":
                        return false;

                    case "1":
                        return true;
                        
                    default:
                        continue;
                }
            }
        }
        static int randomRoll()
        {
            Random rnd = new Random();
            int num =rnd.Next(11);
            return num;
        }

        static void showHP(Character chara , int opponentHp)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{chara.CharName}: {chara.getHealth()}HP \n Enemy: {opponentHp}HP");
            Console.ForegroundColor = ConsoleColor.White;

        }

        static Character gamePlayEvent2(Character chara ,int enemyDamage)
           {
            int enemyHP = 100;
           
            while (true)
            {
                bool fight = actionPlay();
                int roll = randomRoll();
                switch (fight)
                {
                    case true:
                         if (roll == 0)
                        {
                            Console.WriteLine("U landed a critical strike and killed you opponent");

                            enemyHP = 0;
                            showHP(chara, enemyHP);
                        }
                        else if (roll > chara.getStrenght())
                        {
                            Console.WriteLine($"You rolled {roll} and recieved {enemyDamage} Damage ");
                            chara.setHealth(-enemyDamage);
                            showHP(chara, enemyHP);
                        }
                       
                        else
                        {
                            Console.WriteLine($"You rolled {roll} and struck the bandit for {20 * (chara.getStrenght() - roll)}");
                            enemyHP -= (20 * (chara.getStrenght() - roll));
                            showHP(chara, enemyHP);
                        }
                        break;
                    case false:
                          if (roll == 0)
                        {
                            Console.WriteLine($"You have run away and run in to a healer and gained 100HP");
                            chara.setHealth(100);
                            showHP(chara, enemyHP);
                        }
                        else if (roll > chara.getAgility())
                        {
                            Console.WriteLine("You failed to get away and recieved 10 Damage");
                            chara.setHealth(-10);
                            showHP(chara, enemyHP);
                        }
                       
                        else
                        {
                            Console.WriteLine($"You have run away and healed for 40hp");
                            chara.setHealth(40);
                            showHP(chara, enemyHP);
                        }
                        break;
                }
                if (chara.getHealth() < 1)
                {
                    Console.WriteLine("You lose");
                    return chara;
                }
                else if (enemyHP < 1)
                {
                    Console.WriteLine($"You won and have {chara.getHealth()} HP left");
                    return chara;
                }
            }


        }



    }
}
