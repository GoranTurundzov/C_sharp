using CarDealership.Domain.Enum;
using Models.Enum;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vehicle : BaseEntity , IVehicle
    {
        public string Name { get; set; }
        public  string Model { get; set; }

        public int HorsePower { get; set; }

        public int CC { get; set; }

        public int ManufactureYear { get; set; }

        public VehicleType Type { get; set; }

        public FuelType Fuel { get; set; }

        public PaintType Paint { get; set; }
        public string Color { get; set; }

        public int Price { get; set; }

        public int KmPassed { get; set; }

        public Vehicle(string name, string model, int horsePower , int cc , int manufactureYear, VehicleType type , FuelType fuelType , PaintType paint , string color , int kmPassed)
        {
            Name  = name;
            Model = model;
            HorsePower = horsePower;
            CC = cc;
            ManufactureYear = manufactureYear;
            Type = type;
            Fuel = fuelType;
            Random rnd = new Random();
            Id = rnd.Next(100000, 999999);
            Color = color;
            Paint = paint;
            KmPassed = kmPassed;
            // I will think of some other way to set the price for the vehicles
            Price = type == VehicleType.Automobile ? manufactureYear + ((cc + horsePower) * 2)
                : type == VehicleType.Van ? manufactureYear + ((cc + horsePower) * 2) + 6000
                :  manufactureYear + ((cc + horsePower) * 2) + 18000;

        }

        public override string GetInfo()
        {
            return $"[[{Id}]] -- [{Type} / {Fuel}] {Name} : {Model} ({ManufactureYear}) [PRICE: {Price.ToString("C", new CultureInfo("en-GB"))}] \n {KmPassed} {CC}cc/{HorsePower}HP [{Color}-{Paint}] (Chassis Number{Id})  \n";
        }

        public string RestrictedView()
        {
            return $"[[{Type} / {Fuel}] {Name} : {Model} ({ManufactureYear})  \n Km passed: {KmPassed}KM {CC}cc/{HorsePower}HP [{Color}-{Paint}] \n ------------------------------------------------------------------ \n";
        }
        public override string ToString()
        {
            return $"[{Type,10} / {Fuel,8}] {Name,12} : {Model,16} ({ManufactureYear,4})  \n {CC,5}cc/{HorsePower,4}HP [{Color}-{Paint}] {KmPassed}  [PRICE: {Price.ToString("C", new CultureInfo("en-GB"))}]\n \n";
        }

        public void SetPrice(int price)
        {
            Price = price;
        }

        
    }
}
