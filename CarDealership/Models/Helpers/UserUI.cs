using CarDealership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Domain.Database;
using CarDealership.Domain.Enum;
using Models;
using Models.Enum;

namespace CarDealership.Domain.Helpers
{
    public static class UserUI
    {

        public static void HomeScreen()
        {
          
            while (true)
            {
                Console.WriteLine("Select: \n \t 1.Log In. \n \t 2.Continue as Guest \n \t 3.Register \n \t 0.Exit");
                switch (Console.ReadLine())
                {

                    case "1":
                        try {
                        Helper.SlowPrint("Loging in");
                        Console.Clear();
                        User user = LogInUi(ShopDB.Users);
                        Console.WriteLine($"Hello {user.FirstName}");
                            if(user.Type == UserType.Buyer)
                            {
                                CostumerPannel((Costumer) user);
                            } else if(user.Type == UserType.Manager)
                            {
                                ManagerPannel((Manager)user);
                            } else if(user.Type == UserType.Supplyer)
                            {
                                SupplyerPannel((Supplyer)user);
                            }
                           
                        }catch(Exception ex) { Console.WriteLine(ex.Message); }
                        continue;
                    case "2":
                        Helper.SlowPrint("Guest entering");
                        Console.Clear();
                        GuestPannel();
                        Console.WriteLine("To see the prices please register and log in");
                        continue;
                    case "3":
                        User newUser = RegisterPannel();
                        if(newUser != null)
                        {
                            ShopDB.Users.Add(newUser);
                        }
                        continue;
                    case "0":
                        Helper.SlowPrint("Exiting");
                        Console.Clear();
                        break;
                    default:
                        Helper.SlowPrint("Wrong Input Try again ....");
                        Console.Clear();
                        continue;

                }
                break;
            }
        }

        public static User LogInUi(List<User> users)
        {
            Console.WriteLine("Username");
            string username = Console.ReadLine();
            Console.WriteLine("Password");
            string password = Console.ReadLine();

            User user = users.FirstOrDefault(x => x.LogIn(username, password) != null);
            if(user == null)
            {
                throw new Exception("Username/Password incorrect");
            }
            return user;
        }

        public static void ManagerPannel(Manager user)
        {
            while (true)
            {
                Console.WriteLine("Select: \n 1. Vehicle List \n 2. Store Managment \n  0. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine(ShopDB.ShowAllVehicles());
                        continue;
                    case "2":
                        Console.WriteLine(ShopDB.ShowAllEmployees());
                        while (true)
                        {
                            Console.WriteLine("Pick an action");
                            Console.WriteLine("1. Fire an employee");
                            Console.WriteLine("2. Edit Salary");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    while (true)
                                    {
                                        int id = 0;
                                        Console.WriteLine("Who would you like fired?");
                                        if(int.TryParse(Console.ReadLine() , out id))
                                        {
                                            User selected = ShopDB.Users.FirstOrDefault(x => x.Id == id);
                                            if(selected == null)
                                            {
                                                Console.WriteLine("There are not employees with that ID");
                                                break;
                                            } else if(selected.Type == UserType.Manager)
                                            {
                                                Console.WriteLine("You cant fire Managers only the owner can edit them (in the code)");
                                                break;
                                            }
                                            ShopDB.Users.Remove(selected);
                                            break;
                                        }
                                        break;
                                    }
                                    continue;
                                case "2":
                                    while (true)
                                    {
                                        int id = 0;
                                        Console.WriteLine("Who would you like to edit?");
                                        if (int.TryParse(Console.ReadLine(), out id))
                                        {
                                            User selected = ShopDB.Users.FirstOrDefault(x => x.Id == id);
                                            if (selected == null)
                                            {
                                                Console.WriteLine("There are not employees with that ID");
                                                break;
                                            }
                                            else if (selected.Type == UserType.Manager)
                                            {
                                                Console.WriteLine("You cant edit Managers only the owner can edit them (in the code)");
                                                break;
                                            }
                                            UserUI.EditEmployeesSalary(user, (Supplyer)selected);
                                            break;
                                        }
                                        break;
                                    }
                                    continue;
                                case "0":
                                    Helper.SlowPrint("Exiting menu");
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    continue;
                                    
                            }




                            break;
                        }
                        continue;
                    case "0":
                        Helper.SlowPrint("Exiting");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        continue;
                }
                break;
            }
            
        }

        public static void CostumerPannel(Costumer user)
        {
            
            int selected = 0;
            while (true)
            {
                Console.WriteLine($"{user.GetInfo()}");
                Console.WriteLine("Select: \n 1. Buy \n 2. Browse \n 9. Change Password \n 0. Log Out");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        ShopDB.ShowCarsForBuyer();
                        Console.WriteLine("Select A car to Buy");
                        if(!int.TryParse(Console.ReadLine() , out selected) || selected > ShopDB.Vehicles.Count)
                        {
                            Console.WriteLine("Car does not exist");
                            continue;
                        }
                        BuyCar(user, ShopDB.Vehicles[selected - 1]);
                        
                        continue;
                    case "2":
                        Console.WriteLine(ShopDB.ShowAllVehicles());
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    case "9":
                        Console.WriteLine("ChangePassword");
                        Console.WriteLine("Confirm password");
                        if (user.CheckPassword(Console.ReadLine()))
                        {
                            Console.WriteLine("Enter new password");
                            string password = Helper.PasswordValidation();
                            user.ChangePassword(password);
                            Console.WriteLine("Password Succesfully changed");
                        }
                        continue;
                    case "0":
                        Helper.SlowPrint("Loging out...");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        continue;
                }
                break;
            }
            
        }
      

        public static void SupplyerPannel(Supplyer user)
        {
            while (true)
            {
                Console.WriteLine("Select: \n 1. Set Car Price \n 2. Get a new car for the shop \n 0. Exit"  );
                int id = 0;
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(ShopDB.GetCarsForSupplyer());
                        while (true)
                        {
                            Console.WriteLine("Select a car by ID to set a new price");
                            if(!int.TryParse(Console.ReadLine() , out id))
                            {
                                Console.WriteLine("Invalid Selection");
                                continue;
                            }
                            Vehicle car = ShopDB.Vehicles.FirstOrDefault(x => x.Id == id);
                            if (car == null)
                            {
                                Console.WriteLine("No car with that ID exists");
                                continue;
                            }
                            SetCarPrice(user, car);
                            break;
                        }
                        continue;
                    case "2":
                        AquireNewCar();
                        continue;
                    case "0":
                        Helper.SlowPrint("Exiting menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        continue;
                }
            }
        }
        public static void GuestPannel()
        {
            Console.WriteLine(ShopDB.ShowAllVehicles());
        }

        public static Costumer RegisterPannel()
        {
            int funds = 0;
            string username;
            string password;
            string email;
            Console.WriteLine("Please Enter Your Name");
            string name = Console.ReadLine();
            Console.WriteLine("Please Enter your Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age = 0;
            while (true)
            {
               if( !int.TryParse(Console.ReadLine() , out age))
                {
                    Console.WriteLine("Enter you age(numbers)");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("Enter your email");
                email = Console.ReadLine();
                if (!Helper.IsValidEmail(email))
                {
                    Console.WriteLine("Enter an email in a valid format please");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("Enter Username");
                username = Console.ReadLine();
                if(ShopDB.Users.Any(x => x.Username.ToLower() == username.ToLower()))
                {
                    Console.WriteLine("Username is already taken");
                    continue;
                }
                break;
            }
                password = Helper.ConfirmPassword();
            while (true)
            {
                Console.WriteLine("Would you like to add funds to your account? \n 1.Yes \n 2.No");
                switch (Console.ReadLine())
                {
                    case "1":
                        if(int.TryParse(Console.ReadLine() , out funds))
                        {
                            Console.WriteLine($"Succesfully added {funds} to your account");
                            break;
                        }
                        Console.WriteLine("Invalid input");
                        continue;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        continue;
                }
                break;
            }

             return new Costumer(name, lastName, age, email, username, password, funds);
        }

        public static void VehicleBuyUI(User user)
        {

        }

        public static void EditEmployeesSalary(Manager user , Supplyer employee)
        {
            while (true)
            {
                Console.WriteLine("1. Raise");
                int sum = 0;
                Console.WriteLine("2. Lower");
                Console.WriteLine("0 Back");
                switch (Console.ReadLine())
                {
                    case "1":
                        
                        while (true)
                        {
                            Console.WriteLine($"Raise {employee.FirstName} salary by how much?");
                            if(int.TryParse(Console.ReadLine() , out sum))
                            {
                                Console.WriteLine(employee.RaiseSalary(user, sum));
                                break;
                            }
                            Console.WriteLine("Wrong Input");
                        }
                        
                        
                        continue;
                    case "2":
                        
                        while (true)
                        {
                            Console.WriteLine($"Lower {employee.FirstName} salary by how much?");
                            if (int.TryParse(Console.ReadLine(), out sum))
                            {
                               Console.WriteLine(employee.LowerSalary(user, sum));
                                break;
                            }
                            Console.WriteLine("Wrong Input");
                        }

                        continue;
                    case "0":
                        Helper.SlowPrint("Exiting");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        continue;
                }
                break;

            }
        }

        public static void SetCarPrice(Supplyer user , Vehicle car)
        {
            int price = 0;
            Console.WriteLine("New Price?");
            while(!int.TryParse(Console.ReadLine() , out price))
            {
                Console.WriteLine("Invalid input (enter the price in number format)");
            }
            Console.WriteLine($"{user.FirstName} set the price for {car.Name} {car.Model} to {price}");
            car.SetPrice(price);
        }

        public static void AquireNewCar()
        {
            
            string manufacturer;
            string model;
            int cc = 0;
            int hp = 0;
            int year = 0;
            string color;
            bool feature = true;
            VehicleType type = VehicleType.Automobile;
            PaintType colorType = PaintType.Solid;
            FuelType fuel = FuelType.Petrol;
            while (true)
            {

                Console.WriteLine("Select what are you getting \n 1.Automobile \n 2.Van \n 3.Truck");
                switch (Console.ReadLine())
                {
                    case "1":
                        type = VehicleType.Automobile;
                       
                        Console.WriteLine("Does it have a hook? Y/N");
                        feature = Console.ReadLine().ToLower() == "y" ?  true :  false;

                        break;
                    case "2":
                        type = VehicleType.Van;
                        Console.WriteLine("Does it have Back Windows? Y/N");
                        feature = Console.ReadLine().ToLower() == "y" ? true : false;
                        break;
                    case "3":
                        type = VehicleType.Truck;
                        Console.WriteLine("Is it a pick up?");
                        feature = Console.ReadLine().ToLower() == "y" ? true : false;
                        break;
                    case "0":
                        Helper.SlowPrint("Exiting New Car Menu");
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        continue;

                }
                break;
            }
            Console.WriteLine("Enter Vehicle Manufacturer");
            manufacturer = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Model");
            model = Console.ReadLine();
            Console.WriteLine("Year Manufactured");
            
            while(!int.TryParse(Console.ReadLine(), out year) || year < 1950 || year > 2021)
            {
                Console.WriteLine("Invalid Input");
            }
            
            Console.WriteLine("CC?");
            while(!int.TryParse(Console.ReadLine() , out cc))
            {
                Console.WriteLine("Invalid Input");
            }
            Console.WriteLine("Horse Power?");
            while (!int.TryParse(Console.ReadLine(), out hp))
            {
                Console.WriteLine("Invalid Input");
            }
            
            while (true)
            {
                Console.WriteLine("1.Petrol , 2.Diesel , 3. Hybrid , 4.Electric");
                switch (Console.ReadLine())
                {
                    case "1":
                        fuel = FuelType.Petrol;
                        break;
                    case "2":
                        fuel = FuelType.Diesel;
                        break;
                    case "3":
                        fuel = FuelType.Hybrid;
                        break;
                    case "4":
                        fuel = FuelType.Electric;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        continue;
                }
                break;
            }
            Console.WriteLine("Enter Color");
            color = Console.ReadLine();
            
            while (true)
            {
                Console.WriteLine("Type of color? \n 1.Solid  2.Metalic , 3.Pearlescent , 4.Matte");
                switch (Console.ReadLine())
                {
                    case "1":
                        colorType = PaintType.Solid;
                        break;
                    case "2":
                        colorType = PaintType.Metalic;
                        break;
                    case "3":
                        colorType = PaintType.Pearlescent;
                        break;
                    case "4":
                        colorType = PaintType.Matte;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
                break;
            }
            int kilometters = 0;
            while (true)
            {
                Console.WriteLine("1.New  , 2.Used");
                switch (Console.ReadLine())
                {
                    case "1":
                        break;
                    case "2":
                        Console.WriteLine("How many KM has the vehicle passed?");
                        if(!int.TryParse(Console.ReadLine(), out kilometters)) 
                        {
                            Console.WriteLine("Invalid Input");
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        continue;
                }
                break;
            }
            if(type == VehicleType.Automobile)
            {
                ShopDB.Vehicles.Add(new Automobile(manufacturer, model, year, cc, hp, fuel, colorType, color, kilometters, feature));
            } else if(type == VehicleType.Van)
            {
                ShopDB.Vehicles.Add(new Van(manufacturer, model, year, cc, hp, fuel, colorType, color, kilometters, feature));
            } else if(type == VehicleType.Truck)
            {
                ShopDB.Vehicles.Add(new Truck(manufacturer, model, year, cc, hp, fuel, colorType, color, kilometters, feature));
            }

            Console.WriteLine($"New {type} ({manufacturer} : {model}) added to the salon roster");

        }

        public static void BuyCar(Costumer user , Vehicle car)
        {
            if(user.Balance < car.Price)
            {
                Console.WriteLine($"Insufficient funds");
                
            } else
            {
                Console.WriteLine($"Congratulation {user.FirstName} you are the brand new owner of the {car.Name} {car.Model}");
                user.Balance -= car.Price;
                ShopDB.Vehicles.Remove(car);
            }
            
        }
    }
}
