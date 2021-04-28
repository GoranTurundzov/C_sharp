using System;
using Models;
namespace InvoiceApp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Data
            Admin beg = new Admin("BEG",  "BEG", "test123", EnumCompany.BEG);
            Admin evn = new Admin("EVN", "EVN", "test123", EnumCompany.EVN);
            Admin vodovod = new Admin("VODOVOD", "vodovod", "test123", EnumCompany.Vodovod);
            Admin komunalec = new Admin("Komunalec", "gorann", "test123", EnumCompany.BEG);
            User goran = new User("Goran", "Turundzov", 076615042,  "goran", "test123");
            User bob = new User("Bob", "Bobsky", 077777555, "bob", "test123");
            User sara = new User("Sara", "Sarsky", 075434564, "sara", "test123");
            DataBase.Users.Add(beg); DataBase.Users.Add(evn); DataBase.Users.Add(vodovod); DataBase.Users.Add(komunalec); DataBase.Users.Add(goran); DataBase.Users.Add(bob); DataBase.Users.Add(sara);
            #endregion
            try
            {
                while (true)
                {
                    Console.WriteLine("Welcome");
                    Console.WriteLine("Enter Username");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string password = Console.ReadLine();
                    Person loggedUser = DataBase.LogIn(username, password);
                    if (loggedUser.Admin)
                    {
                        Admin admin = (Admin)loggedUser;
                        Console.WriteLine(admin.GetInvoicesByMyCompany(DataBase.Users));
                    }
                    else if (!loggedUser.Admin)
                    {
                        User user = (User)loggedUser;
                        UserUI(user);
                    }
                }


            } catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
            }




        }
        static void UserUI(User user)
        {
            while (true)
            {
                Console.WriteLine("Pick an action: \n 1.See  invoices \n 2.Pay an invoice \n 3.Add funds \n 0.EXIT");
                switch (Console.ReadLine())
                {
                    case "2":
                        Console.Clear();
                        Console.WriteLine(user.GetUnpayedInvoices());
                        Console.WriteLine("Pick an invoice to pay");
                        int i = -1;
                        if(int.TryParse(Console.ReadLine(), out i) && i > 0 && i <= user.Invoices.Count)
                        {
                                    
                        } else
                        {
                            Console.WriteLine("Invalid selection");
                        }
                        continue;
                    case "1":
                        Console.Clear();
                        Console.WriteLine(user.GetInvoices());
                        continue;
                    case "3":
                        int funds = 0;
                        Console.WriteLine("Enter amount");
                        if(!int.TryParse(Console.ReadLine() , out funds))
                        {
                            Console.WriteLine("Invalid input");
                            continue;
                        }
                        user.AddFunds(funds);
                        continue;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        continue;

                }
                break;
            }
        }
    }
}
