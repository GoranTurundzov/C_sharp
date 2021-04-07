using System;
using AtmMachine.Classes;
using System.Globalization;
using System.Text.RegularExpressions;
namespace AtmMachine
{
    class AtmMachine
    {
        static void Main(string[] args)
        {
            User[] users = { new User("Goran", "Turundjov"), new User("Risto", "Pancovski"), new User("Bob", "Bobsky"), new User("test", "test") };
            users[0].SetCardNumber(5555034095125325);
            users[1].SetCardNumber(6060345687248182);
            users[2].SetCardNumber(8888545468238285);
            users[3].SetCardNumber(1111111111111111);
            users[0].SetPin(0052);
            users[1].SetPin(1254);
            users[2].SetPin(5555);
            users[3].SetPin(1111);
            while (true)
            {
                Console.WriteLine("Select: \n 1.Log in     \n 2.Register   \n 3.Shut Down");
                string selected = Console.ReadLine();
                switch (selected)
                {
                    case "1":
                        int activeUser = LogInAtm(users);
                        if(activeUser == -1)
                        {
                            Console.WriteLine("Invalid Card Number or PIN");
                            continue;
                        }
                        UserInterFace(users[activeUser]);
                       
                        continue;

                    case "2":
                        Console.WriteLine(users.Length);
                        users = RegisterUser(users);
                        continue;
                    case "admin":
                        PrintUsers(users);
                        continue;
                    case "3":
                        Console.WriteLine("Shutting Down.");
                        break;
                    default:
                        continue;




                }
                break;
            }



        }




        static int LogInAtm(User[] users)
        {
            long cardNumber = CheckCard();
            int pinNumber = CheckPin();
            bool userFound = false;
            int numberOfUser = -10;
            for (int i = 0; i < users.Length; i++)
            {
               
                if (users[i].GetCardNumber() == cardNumber && users[i].GetPinNumber() == pinNumber)
                {
                    Console.WriteLine($"Welcome {users[i].Name} {users[i].LastName}");
                    numberOfUser = i;
                    userFound = true;
                    break;
                }

            }
            if (userFound)
            {
                return numberOfUser;
            } else
            {
                return -1;
            }

            
        }
        static User[] RegisterUser(User[] users)
        {
            long cardNumber = CheckCard();
            int cardPin = CheckPin();
            
            Console.WriteLine("Enter Name Please");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name please");
            string lastName = Console.ReadLine();
            
            Array.Resize(ref users, users.Length + 1);
            users[users.Length - 1] = new User(firstName, lastName);
            users[users.Length - 1].SetCardNumber(cardNumber);
            users[users.Length - 1].SetPin(cardPin);

            return users;


        }
        static long CheckCard()
        {
            long cardNumber = 0;
            while (true)
            {
               
                Console.WriteLine("Please Enter Card Number");
                Regex reg = new Regex("[^0-9.]");
                string cardNumberString = reg.Replace(Console.ReadLine(), "");
                if (long.TryParse(cardNumberString, out cardNumber) && cardNumberString.Length == 16)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter you 16 digit number shown on the front of the card (without the dashes)");
                }
            }
            return cardNumber;
        } 
        static int CheckPin()
        {
            int pinNumber;
            while (true)
            {
                Console.WriteLine("Please Enter PIN Number");
                string pinNumberString = Console.ReadLine();
                if (int.TryParse(pinNumberString, out pinNumber) && pinNumberString.Length == 4)
                {
                    break;
                }
                else { Console.WriteLine("Enter 4digit PIN please"); }
            }
            return pinNumber;
        }
        static User UserInterFace(User user)
        {
           
            while (true)
            {

                Console.WriteLine($"Select: \n 1.Withdraw  \n 2.Deposit \n 3.Change PIN  \n 4.Exit");
                string userSelect = Console.ReadLine();
                switch (userSelect)
                {
                
                    case "1":
                        Witdraw(user);
                        continue;
                    case "2":
                        Deposit(user);
                        continue;
                    case "3":
                        ChangePin(user);
                        continue;
                    case "4":
                        Console.WriteLine("Thank You for using our ATM");
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                    continue;

            }
            return user;
        }
           
        }
        static User Witdraw(User user)
        {
            Console.WriteLine($"{user.ShowInfo()}");
            int sum = 0;
            while (true)
            {
                Console.WriteLine("Enter sum you want to withdraw");
                string withdraw = Console.ReadLine();
                if(int.TryParse(withdraw, out sum))
                {
                    if(user.Balance > sum)
                    {
                        break;
                    } else { Console.WriteLine("Insuficient Funds"); }

                }
                else
                {
                    Console.WriteLine("Invalid Number");
                }
               
            }
            user.Witdraw(sum);
            Console.WriteLine($"Withdrawing {sum.ToString("C", new CultureInfo("en-US"))} \n Balance: {user.Balance.ToString("C", new CultureInfo("en-US"))}");
            return user;
        }
        static User Deposit(User user)
        {
            int sum;
            
            while (true)
            {
                Console.WriteLine("Enter sum you want to deposit");
                string deposit = Console.ReadLine();
                if (int.TryParse(deposit, out sum)){
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid sum format");
                }
            }
            Console.WriteLine($"Current Balance: {user.Balance.ToString("C", new CultureInfo("en-US"))} \n processing...");
            user.Balance += sum;
            Console.WriteLine($"New Balance: {user.Balance.ToString("C", new CultureInfo("en-US"))}");
            return user;
        }
        static User ChangePin(User user)
        {
            int newPin = CheckPin();
            user.SetPin(newPin);

            return user;
        }
        static void PrintUsers(User[] users)
        {
            foreach(User user in users)
            {
                Console.WriteLine( user.ShowInfo());
            }
        }
    }
}
