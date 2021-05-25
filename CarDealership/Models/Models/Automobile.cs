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
    public class Automobile : Vehicle , IAutomobile
    {

        public bool HasTrailerHook { get; set; }

        public Automobile(string name,string model,  int manufactureYear, int cc, int horsePower, FuelType fuel, PaintType paint, string color , int kmPassed, bool hasTrailerHook) 
            : base(name , model , horsePower , cc, manufactureYear , VehicleType.Automobile, fuel , paint , color, kmPassed)
        {
            HasTrailerHook = hasTrailerHook;

        }
    }
}
