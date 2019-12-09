using Microsoft.AspNetCore.Mvc;
using MobileStore.DataModels;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Views.Shared.Components.Carousel
{
    public class CarouselViewComponent : ViewComponent
    {
        public CarouselViewComponent() { }

        public IViewComponentResult Invoke(CarouselViewModel carousel)
        {
            return View(carousel);
        }
    }

}
