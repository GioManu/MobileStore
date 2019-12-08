using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.DataModels
{
    public class Product
    {
        public int MobileProductID { get; set; }
        public int RAM { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public string Size { get; set; }
        public string CPU { get; set; }
        public string OS { get; set; }
        public string VideoUrl { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
