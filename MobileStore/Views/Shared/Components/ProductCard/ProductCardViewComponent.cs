using Microsoft.AspNetCore.Mvc;
using MobileStore.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Views.Shared.Components.ProductCard
{
    public class ProductCardViewComponent : ViewComponent
    {
        public ProductCardViewComponent() { }

        public IViewComponentResult Invoke(Product prod)
        {
            return View(prod);
        }
    }
}
