using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.DataModels
{
    public class Manufacturer
    {
        public int ManufaturerID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
