using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.DataModels
{
    public class ProductImage
    {
        public int ImageID { get; set; }
        public string ImageUrl { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
