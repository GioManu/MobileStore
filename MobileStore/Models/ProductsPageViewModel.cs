using MobileStore.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class ProductsPageViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public SearchBarViewModel SearchBarParams { get; set; }
        public PageViewModel PageParams { get; set; }
    }
}
