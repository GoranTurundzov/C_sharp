using CarDealership.Domain.Enum;
using Models;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Domain.Models
{
    public class Van : Vehicle
    {

        public bool HasBackWindows { get; set; }
        public Van(string name, string model, int manufactureYear, int cc, int horsePower, FuelType fuel, PaintType paint, string color , int kmPassed , bool hasBackWindows)
            : base(name, model, horsePower, cc, manufactureYear, VehicleType.Van, fuel, paint, color , kmPassed)
        {
            HasBackWindows = hasBackWindows;
        }
    }
}
