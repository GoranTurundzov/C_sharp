using CarDealership.Domain.Enum;
using CarDealership.Domain.Models;
using Models;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Domain.Database
{
    public static class ShopDB
    {

        public static List<User> Users { get; set; } = new List<User>();
        
        public static List<Supplyer> Supplyers { get; set; } = new List<Supplyer>
        {
             //new Supplyer("Steve" , "Stevenson" , 35, "Stevce@hotmail.com" , "Steven" , "test123"),
             //new Supplyer("Miki" , "Mikiansen" , 35, "Miki@hotmail.com" , "miki" , "test123")
        };
        public static List<Manager> Managers { get; set; } = new List<Manager>
        {
             //new Manager("Jas" , "Sum" , 45 , "JasSum@outlook.com" , "jasum" , "test123" , 10),
             //new Manager("George" , "Georgiev" , 45 , "GeorgeGeor@outlook.com" , "george" , "test123" , 10)
        };

        public static List<Costumer> Costumers { get; set; } = new List<Costumer>
        {
             //new Costumer("Goran" , "Turundzov" , 28 , "goran.Turunddzov1@gmail.com", "goran" , "test123" , 55000),
             //new Costumer("Zoran" , "Bratmunagoran" , 28 , "Zoran.Bratmunagoran@gmail.com", "zoran" , "test123" , 7000),
             //new Costumer("Bob" , "Bobsky" , 28 , "Bob.Bobsky@gmail.com", "bob" , "test123" , 15235),
             //new Costumer("Sara" , "Sarsky" , 28 , "Sara.Sarsky@gmail.com", "sara" , "test123" , 10000000),
             //new Costumer("Jon" , "Doe" , 28 , "Jon.Doe@gmail.com", "Jon" , "test123" , 6024)

        };

        public static List<Van> Vans { get; set; } = new List<Van>
        {
            //new Van("Mercedes" , "Sprinter" , 2005 , 3500 , 160 , FuelType.Diesel , PaintType.Matte , "Black" ,250000, true ),
            //new Van("Mercedes" , "Sprinter" , 2005 , 3500 , 160 , FuelType.Diesel , PaintType.Matte , "Black" , 330000, true ),
            //new Van("Honda" , "Odyssey" , 2020 , 2500 , 160 , FuelType.Petrol , PaintType.Pearlescent , "White" , 10,  false ),
            //new Van("Ford" , "Transit Connect" , 2020 , 2000 , 130 , FuelType.Diesel , PaintType.Metalic , "White" , 0,  false ),
            //new Van("Toyota" , "Sienna" , 2005 , 3500 , 296 , FuelType.Diesel , PaintType.Pearlescent , "Black" ,160000, true ),
            //new Van("Ram" , "ProMastersW" , 2017 , 3500 , 296 , FuelType.Diesel , PaintType.Pearlescent , "White" , 33300 ,true ),
            //new Van("Ram" , "ProMastersC" , 2017 , 3500 , 296 , FuelType.Diesel , PaintType.Pearlescent , "White" , 25223, false )
        };

        public static List<Truck> Trucks { get; set; } = new List<Truck>
        {
            //new Truck("Chevrolet" , "Colorado" , 2020 , 4000 , 302 , FuelType.Diesel , PaintType.Matte , "Grey" ,6000, true  ),
            //new Truck("IVECO" , "S-WAY" , 2020 , 6500 , 570 , FuelType.Diesel , PaintType.Pearlescent , "Blue" ,0 , false ),
            //new Truck("Kenworth" , "W990" , 2020 , 7000 , 565 , FuelType.Diesel , PaintType.Metalic , "Yellow" , 6500 , false ),
            //new Truck("Scania" , "R 580" , 2020 , 4000 , 580 , FuelType.Diesel , PaintType.Pearlescent , "Blue" ,7000, true  ),
            //new Truck("Volvo " , "Iron Knight" , 2020 , 10000 , 2400 , FuelType.Diesel , PaintType.Pearlescent , "White" , 0 , true  )
        };

        public static List<Automobile> Automobiles { get; set; } = new List<Automobile>
        {
            //new Automobile("Honda" , "Civic" , 2015 , 2000 , 150 , FuelType.Petrol , PaintType.Pearlescent , "Black" , 70000 , false)
        };

        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
     

        public static List<Vehicle> ShowAllAutomobiles(VehicleType type)
        {
            List<Vehicle> auto = new List<Vehicle>();
            if(type == VehicleType.Automobile)
            {
               
            } else if(type == VehicleType.Van)
            {
                auto.AddRange(Vans);
            } else if (type == VehicleType.Truck)
            {
                auto.AddRange(Trucks);
            }
            return auto;
        }
        public static string ShowAllVehicles()
        {
            
            string print = "Vehicles: \n";
            print += string.Join("-", Vehicles);
            return print;
        }
        public static string ShowForGuest()
        {
            string print = "Vehicles: \n";
            foreach(Vehicle vehicle in Vehicles)
            {
                print += vehicle.RestrictedView();
            }
            return print;
        }
        public static string GetCarsForSupplyer()
        {
            string cars = "";
            List<Vehicle> auto = new List<Vehicle>();
            auto = auto.Concat(Automobiles).Concat(Trucks).Concat(Trucks).ToList();
            foreach (Vehicle car in auto)
            {
                cars += $"{car.GetInfo()} \n";
            }
            return cars;
        }

        public static string ShowAllEmployees()
        {
            string print = "Employees: \n";
            List<User> employees = new List<User>();
            employees = employees.Concat(Managers).Concat(Supplyers).ToList();
          
           for(int i = 0; i < employees.Count; i++)
            {
                print += $"{employees[i].Id}. {employees[i].GetInfo()} \n";
            } 
           return print;
        }

        public static void ShowCarsForBuyer()
        {
            
            int counter = 1;
            for(int i = 0; i < Vehicles.Count; i++)
            {
                Console.WriteLine($"{counter}. {Vehicles[i].GetInfo()}");
                counter++;
            }
        }
    }
}
