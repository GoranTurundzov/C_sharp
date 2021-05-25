using CarDealership.Domain.Enum;
using CarDealership.Domain.Interfaces;
using Models;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Domain.Models
{
    public class Truck : Vehicle , ITruck
    {
      

        public bool IsPickUp { get; set; }

        public Truck(string name, string model, int manufactureYear, int cc, int horsePower, FuelType fuel, PaintType paint, string color, int kmPassed, bool isPickUp)
            : base(name, model, horsePower, cc, manufactureYear, VehicleType.Truck, fuel, paint, color , kmPassed)
        {
           
            IsPickUp = isPickUp;
        }
    }
}
