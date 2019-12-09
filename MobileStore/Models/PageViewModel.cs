using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class PageViewModel
    {
        public int TotalPages { get; set; }
        public PageParametersViewModel PageParams { get; set; }
    }
}
