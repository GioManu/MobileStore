using MobileStore.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class ProductViewModel
    {
        public Product product { get;set; }
        public CarouselViewModel Carousel { get; set; }

    }
}
