using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class PageParametersViewModel
    {
        public int page { get; set; }
        public int manufacturer { get; set; }
        public string name { get; set; }
        public decimal price_from { get; set; }
        public decimal price_to { get; set; }

        public PageParametersViewModel()
        {
            this.page = 1;
            this.name = "";
        }
    }
}
