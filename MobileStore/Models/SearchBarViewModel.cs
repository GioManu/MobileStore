using MobileStore.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class SearchBarViewModel
    {
        public IEnumerable<Manufacturer> manufacturers { get; set; }
        public PageParametersViewModel pageParams { get; set; }
    }
}
