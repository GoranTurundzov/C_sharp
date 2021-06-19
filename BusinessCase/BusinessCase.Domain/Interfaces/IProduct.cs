using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCase.Domain.Interfaces
{
    public interface IProduct
    {
        string Name { get; set; }
        bool Domestic { get; set; }
        double Price { get; set; }
        string Description { get; set; }
        double? Weight { get; set; }
    }
}
