using System;
using System.Globalization;

namespace PizzaPlace
{
    class Program
    {
        static void Main(string[] args)
        {
          

                Console.WriteLine("WELCOME TO OUR RESTORAUNT!");
                bool selected = false;
                int day = 0;
                int orders = 0;
                string[] days = { " ", "Monday", "Tuesday", "Wednesday", "Thirsday", "Friday", "Saturday", "Sunday" };
                bool wantToOrder = false;



                do
                {


                    do
                    {
                        Console.WriteLine("Select 1 For Monday");
                        Console.WriteLine("Select 2 For Tuesday");
                        Console.WriteLine("Select 3 For Wednesday");
                        Console.WriteLine("Select 4 For Thirsday");
                        Console.WriteLine("Select 5 For Friday");
                        Console.WriteLine("Select 6 For Saturday");
                        Console.WriteLine("Select 7 For Sunday");


                        selected = int.TryParse(Console.ReadLine(), out day);
                        if (day > 0 && day < 8)
                        {
                            Console.WriteLine($"Selected: {days[day]}");
                        }
                        else
                        {
                            selected = false;
                        }
                    } while (!selected);
                    do
                    {
                        Console.WriteLine("Enter Number of Orders Please (1 - 30)");
                        selected = false;
                        selected = int.TryParse(Console.ReadLine(), out orders);
                        if (orders > 0 && orders < 31)
                        {
                            Console.WriteLine($"{orders} orders for {days[day]}");
                        }
                        else
                        {
                            selected = false;
                        }
                    } while (!selected);
                    double regularPrice = 0;
                    double elitePrice = 0;
                    switch (day)
                    {
                        case 1:
                        case 2:
                        case 3:
                            regularPrice = 300;
                            elitePrice = 400;
                            Console.WriteLine($"Prices: \n  Regular Pizza:{regularPrice.ToString(new CultureInfo("mk-US"))} \n  Elite Pizza: { elitePrice.ToString(new CultureInfo("mk-MK"))}");
                            break;
                        case 4:
                        case 5:
                            regularPrice = 350;
                            elitePrice = 500;
                            Console.WriteLine($"Prices: \n  Regular Pizza:{regularPrice.ToString(new CultureInfo("mk-MK"))} \n  Elite Pizza: { elitePrice.ToString(new CultureInfo("mk-MK"))}");
                            break;
                        case 6:
                        case 7:
                            regularPrice = 400;
                            elitePrice = 550;
                            Console.WriteLine($"Prices: \n  Regular Pizza:{regularPrice.ToString(new CultureInfo("mk-MK"))} \n  Elite Pizza: { elitePrice.ToString(new CultureInfo("mk-MK"))}");
                            break;
                    }
                    bool pizzaSelector = false;
                    int selector = 0;
                    do
                    {
                        Console.WriteLine("For Regular orders select \"1\"  for elite select \"2\" ");
                        string pizzaSelected = Console.ReadLine();
                        if (pizzaSelected == "1")
                        {
                            selector = int.Parse(pizzaSelected);
                            pizzaSelector = true;
                            Console.WriteLine("Regular Option Selected");
                        }
                        else if (pizzaSelected == "2")
                        {
                            selector = int.Parse(pizzaSelected);
                            pizzaSelector = true;
                            Console.WriteLine("Elite option Selected");
                        }
                    } while (!pizzaSelector);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (selector == 1)
                    {
                        if ((day == 4 || day == 5) && orders > 3)
                        {
                            Console.WriteLine($"Reserved: {days[day]} {orders} for the price of {regularPrice} for a total of {(orders * regularPrice).ToString(new CultureInfo("mk-MK"))}");
                            Console.WriteLine($"Large Order discount of 30%  for a total of {((orders * regularPrice) * 0.7).ToString(new CultureInfo("mk-MK"))}");
                        }
                        else if ((day == 6 || day == 7) && orders > 5)
                        {
                            Console.WriteLine($"Reserved: {days[day]} {orders} for the price of {regularPrice} for a total of {(orders * regularPrice).ToString(new CultureInfo("mk-MK"))}");
                            Console.WriteLine($"Large Order discount of 35%  for a total of {((orders * regularPrice) * 0.65).ToString(new CultureInfo("mk-MK"))}");
                        }
                        else
                        {
                            Console.WriteLine($"Reserved: {days[day]} {orders} for the price of {regularPrice} for a total of {(orders * regularPrice).ToString(new CultureInfo("mk-MK"))}");
                        }
                    }
                    else if (selector == 2)
                    {
                        if ((day == 6 || day == 7) && orders > 4)
                        {
                            Console.WriteLine($"Reserved: {days[day]} {orders} for the price of {elitePrice} for a total of {orders * elitePrice}");
                            Console.WriteLine($"Large Order discount of 40%  for a total of {(orders * elitePrice) * 0.6}");
                        }
                        else if (orders > 6)
                        {
                            Console.WriteLine($"Reserved: {days[day]} {orders} for the price of {elitePrice} for a total of {(orders * elitePrice).ToString(new CultureInfo("mk-MK"))}");
                            Console.WriteLine($"Large Order discount of 20%  for a total of {((orders * elitePrice) * 0.8).ToString(new CultureInfo("mk-MK"))}");
                        }
                        else
                        {
                            Console.WriteLine($"Reserved: {days[day]} {orders} for the price of {elitePrice} for a total of {(orders * elitePrice).ToString(new CultureInfo("mk-MK"))}");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Please enter \"Y\" if u want to Place another order");
                    string shop = Console.ReadLine();
                    if (shop == "y" || shop == "Y")
                    {
                        wantToOrder = true;
                    }
                } while (wantToOrder);

                Console.WriteLine("Thank you for your order");
            }
        }
    }

