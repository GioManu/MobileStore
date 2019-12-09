using MobileStore.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class CarouselViewModel
    {
        public IEnumerable<ProductImage> Images { get; set; }
        public String VideoUrl { get; set; }
    }
}
