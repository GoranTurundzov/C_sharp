using BusinessCase.Domain.Interfaces;
using System;

namespace BusinessCase.Domain
{
    public class Product : IProduct
    {

        public string Name { get; set; }
        public bool Domestic { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double? Weight { get; set; }

    }
}
