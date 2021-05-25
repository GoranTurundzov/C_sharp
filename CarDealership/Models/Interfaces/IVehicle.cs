using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    interface IVehicle 
    {
        string Name { get; set; }

        int HorsePower { get; set; }

        int CC { get; set; }

        int ManufactureYear { get; set; }

        VehicleType Type { get; set; }

       

    }
}
