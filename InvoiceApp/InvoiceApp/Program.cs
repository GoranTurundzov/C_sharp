using System;
using Models;
namespace InvoiceApp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Data
            User goran = new User("Goran", "Turundzov", 076615042,  "goran", "test123");
            goran.Invoices.Add(new Invoice("Struja", EnumCompany.EVN, new DateTime(2021, 02, 27), new DateTime(2021, 03, 27), 1273 ));
            goran.Invoices.Add(new Invoice("Struja", EnumCompany.EVN, new DateTime(2021, 03, 27), new DateTime(2021, 04, 27), 1203));
            goran.Invoices.Add(new Invoice("Voda", EnumCompany.Vodovod, new DateTime(2021, 04, 27), new DateTime(2021, 05, 27), 513, true) );
            goran.Invoices.Add(new Invoice("Voda", EnumCompany.Vodovod, new DateTime(2021, 03, 27), new DateTime(2021, 04, 27), 517));
            goran.Invoices.Add(new Invoice("Parno", EnumCompany.BEG, new DateTime(2021, 04, 27), new DateTime(2021, 05, 28), 1513, true) );
            goran.Invoices.Add(new Invoice("Parno", EnumCompany.BEG, new DateTime(2021, 03, 27), new DateTime(2021, 04, 28), 1513));
            User bob = new User("Bob", "Bobsky", 077777555, "bob", "test123");
           bob.Invoices.Add(new Invoice("Struja", EnumCompany.EVN, new DateTime(2021, 02, 15), new DateTime(2021, 03, 14), 1334 , true) );
           bob.Invoices.Add(new Invoice("Struja", EnumCompany.EVN, new DateTime(2021, 03, 15), new DateTime(2021, 04, 14), 1003 , true) );
           bob.Invoices.Add(new Invoice("Voda", EnumCompany.Vodovod, new DateTime(2021, 04, 25), new DateTime(2021, 05, 26), 513, true) );
           bob.Invoices.Add(new Invoice("Voda", EnumCompany.Vodovod, new DateTime(2021, 03, 25), new DateTime(2021, 04, 26), 517, true) );
           bob.Invoices.Add(new Invoice("Parno", EnumCompany.BEG, new DateTime(2021, 04, 17), new DateTime(2021, 05, 18), 1513));
           bob.Invoices.Add(new Invoice("Parno", EnumCompany.BEG, new DateTime(2021, 03, 17), new DateTime(2021, 04, 18), 1513));
            User sara = new User("Sara", "Sarsky", 075434564, "sara", "test123");
            sara.Invoices.Add(new Invoice("Struja", EnumCompany.EVN, new DateTime(2021, 02, 05), new DateTime(2021, 03, 06), 1334));
            sara.Invoices.Add(new Invoice("Struja", EnumCompany.EVN, new DateTime(2021, 03, 06), new DateTime(2021, 04, 07), 1856, true) );
            sara.Invoices.Add(new Invoice("Voda", EnumCompany.Vodovod, new DateTime(2021, 04, 25), new DateTime(2021, 05, 26), 513));
            sara.Invoices.Add(new Invoice("Voda", EnumCompany.Vodovod, new DateTime(2021, 03, 25), new DateTime(2021, 04, 26), 517));
            sara.Invoices.Add(new Invoice("Parno", EnumCompany.BEG, new DateTime(2021, 04, 17), new DateTime(2021, 05, 18), 1513, true));
            sara.Invoices.Add(new Invoice("Parno", EnumCompany.BEG, new DateTime(2021, 03, 17), new DateTime(2021, 04, 18), 1513));
            DataBase.Users.Add(goran); DataBase.Users.Add(bob); DataBase.Users.Add(sara);
            #endregion
           
                while (true)
                {
                try {
                    Console.Clear();
                    Console.WriteLine("Welcome");
                    Console.WriteLine("Enter Username");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string password = Console.ReadLine();
                    Person loggedUser = DataBase.LogIn(username, password);
                    if (loggedUser.Admin)
                    {
                       
                       Admin admin = (Admin)loggedUser;
                        Console.Clear();
                        Console.WriteLine(admin.GetInvoicesByMyCompany());
                        Helper.PressToContinue();
                        Console.Clear();
                    }
                    else if (!loggedUser.Admin)
                    {
                        User user = (User)loggedUser;
                        
                        UserUI(user);
                    }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }


            




        }
        static void UserUI(User user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(user.GetInfo());
                Console.WriteLine("Pick an action: \n 1.See  invoices \n 2.Pay an invoice \n 3.Add funds \n 0.EXIT");
                switch (Console.ReadLine())
                {
                    case "2":
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(user.GetInfo());
                            Console.WriteLine(user.GetUnpayedInvoices());
                            Console.WriteLine("Pick an invoice to pay");
                            user.PayInvoice();
                            Helper.PressToContinue();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        continue;
                    case "1":
                        Console.Clear();
                        Console.WriteLine(user.GetInfo());
                        Console.WriteLine(user.GetInvoices());
                        Helper.PressToContinue();
                        continue;
                    case "3":
                        Console.Clear();
                        int funds = 0;
                        Console.WriteLine(user.GetInfo()); 
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
