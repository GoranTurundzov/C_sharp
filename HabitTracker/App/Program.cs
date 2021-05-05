using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace App
{
    class Program
    {
        
        static void Main(string[] args)
        {




            #region testUsers
            User goran = new User("Goran", "Password", "Goran@goran.com", "pinn");
            Habit smoking = new BadHabit("smoking", Group.Other, Difficulty.Medium);
            Habit swimming = new GoodHabit("swimming", Group.Exercise_and_Sport, Difficulty.Hard);
            goran.AddHabit(smoking);
            goran.AddHabit(swimming);
            User bob = new User("bob", "bob123", "Bob@bob.bob" , "1234");
            bob.AddHabit(smoking);
            bob.AddHabit(swimming);

        #endregion

            List<User> users = new List<User> { goran, bob };
            while (true)
             
            {
                try
                {
                    Console.WriteLine($" 1.Log In \n 2.Create Account \n 3.Exit");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            User user = LogIn(users);
                            UserUI(user);
                            continue;
                        case "2":
                            Console.WriteLine("REGISTER");
                            User newUser = CreateAccount(users);
                            users.Add(newUser);

                            continue;
                        case "3":
                            Exiting("EXITING APPLICATION... \n GOODBYE!");
                            break;
                        case "admin":
                            foreach (User registeredUser in users)
                            {
                                Console.WriteLine(registeredUser.GetInfo());
                            }
                            Console.WriteLine(" \n \n \n Press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        default:
                            continue;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
           
               

        }
        #region AccountCreation

        static User CreateAccount(List<User> users)
        {
            Console.WriteLine("Enter Username!");
            string username = setUsernameNewUser(users);
            string email = setEmailNewUser(users);
            string password = ConfirmPassword();
            string pin = ConfirmPin();
            User user = new User(username, password, email , pin );
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Account {username} created");
            Console.ForegroundColor = ConsoleColor.White;
            return user;
        }

      
       
        static string setEmailNewUser(List<User> users)
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
                        if (enteredEmail.ToLower() == account.Email)
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
        static string setUsernameNewUser(List<User> users)
        {
            while (true)
            {
                bool found = false;
                string username = Console.ReadLine();
                foreach (User account in users)
                {
                    if (account.Username == username.ToLower())
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
        #endregion

        #region Validations
       
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

        static string PasswordValidation ()
        {
            while (true)
            {
                Console.WriteLine("Enter password (Must be at least 6 characters long and contain at least 1 number");
                string password = Console.ReadLine();
                bool contains = false;
                char[] pass = password.ToCharArray();
                foreach(char a in pass)
                {
                    if(int.TryParse(a.ToString() , out int number))
                    {
                        contains = true;
                    }
                }
                if(password.Length  >5 && contains)
                {
                    return password;
                }
               throw new Exception("Password Must be at least 6 characters long and contain at least 1 number");
               


            }

        }

        static string ConfirmPassword()
        {
            while (true)
            {

                string pass1 = PasswordValidation();
                Console.WriteLine("Confirm password");
                string pass2 = Console.ReadLine();
                if (pass1 == pass2)
                {
                    return pass1;
                }
                else
                {
                  Console.WriteLine("Passwords did not match");
                   
                }
            }

        }
        static string ConfirmPin()
        {
            while (true)
            {

                string pass1 = PasswordValidation();
                Console.WriteLine("Confirm password");
                string pass2 = Console.ReadLine();
                if (pass1 == pass2)
                {
                    return pass1;
                }
                else
                {
                    Console.WriteLine("Pins did not match");

                }
            }
        }


        #endregion
        #region UserUi/LogIn
        static void UserUI(User user)
        {
            Console.Clear();
            while (true)
            {
                
                Console.WriteLine("Pick an action: \n 1.Add new Habit  \n 2.Log a Habit \n 3.Remove a Habit \n 4.Stats \n 5.EXIT");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Add a new habit");
                        if (user.CheckPin(Console.ReadLine()))
                        {
                            AddNewHabit(user);
                        }else
                        {
                            throw new Exception("Incorrect Pin");
                        }
                    
                        
                        continue;
                    case "2":
                        Console.Clear();
                        LogTheHabbit(user);
                        Console.Clear();
                        Console.WriteLine("HABIT LOGED");
                        continue;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("DELETING HABIT MENU");
                        DeleteHabit(user);
                        Console.Clear();
                        Console.WriteLine("HABIT DELETED");
                        continue;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("STATS");
                        Console.WriteLine(user.Stats());
                        continue;
                    case "5":
                        Console.Clear();
                        Exiting("EXITING....");
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        continue;
                }
                break;
            }
        }

        static User LogIn(List<User> users)
        {
            while (true)
            {
                Console.WriteLine("Enter Username ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string password = Console.ReadLine();
                User user = users.FirstOrDefault(x => x.LogIn(username, password) != null);
                if (user == null)
                {
                    Console.Clear();
                    throw new Exception("Username/Password incorrect");
                }

                return user;
            }
        }





        #endregion
        #region Habit


        #region CreatingHabit
        static void AddNewHabit(User user)
        {
            
                Console.WriteLine("Habit Name?");
                string habitName = Console.ReadLine();
                if (!user.Habits.Any(x => x.HabitName.ToLower() == habitName.ToLower()))
                {
                    Difficulty difficultyLevel = DificultyLevel();
                    Group group = GroupPicker();
                    while (true)
                    {
                        Console.WriteLine("Enter 1 for Good Habit \n Enter 2 for Bad Habit");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                user.Habits.Add( new GoodHabit(habitName, group, difficultyLevel));
                                break;

                            case "2":
                                user.Habits.Add(new BadHabit(habitName, group, difficultyLevel));
                                break;
                            default:
                                Console.WriteLine("WrongInput");
                                continue;
                        }
                        break;
                    }
                  
                }
                else
                {
                    Console.WriteLine("You Already have this Habit");
                    
                }
  
            
           
           
           

            
        }

        static Difficulty DificultyLevel()
        {
            while (true)
            {
                Console.WriteLine($"Pick a Dificulty level:  \n 1.Low \n 2.Medium \n 3.Hard");
                switch (Console.ReadLine())
                {
                    case "1":
                        return Difficulty.Low;
                      
                    case "2":
                        return Difficulty.Medium;
                       
                    case "3":
                        return Difficulty.Hard;
                    default:
                        Console.WriteLine("Wrong Input, Try again");
                        continue;

                }
            }
        }
       static Group GroupPicker()
        {
            while (true)
            {
                Console.WriteLine("Pick a group \n 1.Exercise and Sport \n 2.Study and Learning \n 3.Activities and Hobbies \n 4.Work and Career \n 5.Home and Personal \n 6.Other");
                switch (Console.ReadLine())
                {
                    case "1":
                        return Group.Exercise_and_Sport;
                    case "2":
                        return Group.Study_and_Learning;
                    case "3":
                        return Group.Activities_and_Hobbies;
                    case "4":
                        return Group.Work_and_Career;
                    case "5":
                        return Group.Home_and_Personal;
                    case "6":
                        return Group.Other;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Input");
                        continue;

                       
                }

               
            }
         
        }
        #endregion
        static void DeleteHabit(User user)
        {
            while (true)
            {
                int selected = 0;
                if(user.Habits.Count == 0)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"There are no Habits LOGED");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                Console.WriteLine("Choose a habbit to delete");

                Console.WriteLine(user.ListHabits());

                bool picked = int.TryParse(Console.ReadLine(), out selected);
                if(picked && selected > 0 && selected <= user.Habits.Count)
                {
                    user.DeleteHabit(selected);
                    break;
                }
                Console.WriteLine("Wrong Input");
            }
        }

        static void LogTheHabbit(User user)
        {
            if (user.Habits.Count == 0)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"There are no Habits LOGED");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            int i = -1;
                while (true)
                {

                Console.WriteLine("Choose a habbit to Log");
                Console.WriteLine(user.ListHabits());
                if (!int.TryParse(Console.ReadLine(), out  i) || i < 1 || i > user.Habits.Count)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                
                int minutes = 0;
                Console.WriteLine($"How many minutes did you spend on {user.Habits[i - 1].HabitName}?");
                    if(int.TryParse(Console.ReadLine(), out minutes))
                    {
                        user.Habits[i - 1].LogHabit(minutes);
                        break;
                    }
                    Console.WriteLine("Enter minutes please (number format)");
                
                
            }

        }
        static Habit PickedHabit(User user)
        {
           
            while (true)
            {
                int selected = 0;
                bool picked = int.TryParse(Console.ReadLine(), out selected);
                if (picked && selected > 0 && selected <= user.Habits.Count)
                {
                    return user.Habits[selected - 1];

                }
                Console.WriteLine("Wrong Input");
            }

        }

        #endregion




        static void Exiting(string txt)
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
