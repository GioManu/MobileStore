using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileStore.DataModels;
using MobileStore.Models;
using MobileStore.Repos;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository ProdRepo;
        private IContentRepository ContentRepo;
        private IManufacturerRepository ManuRepo;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IProductRepository ProdRepo,IContentRepository ContentRepo,IManufacturerRepository ManuRepo)
        {
            _logger = logger;

            this.ProdRepo = ProdRepo;
            this.ContentRepo = ContentRepo;
            this.ManuRepo = ManuRepo;
        }

        public IActionResult Index(PageParametersViewModel pageParams)
        {
            if(pageParams.PriceFrom <= 0) { pageParams.PriceFrom = 0; }
            if(pageParams.PriceTo <= 0) { pageParams.PriceTo = 0; }



            ProductsPageViewModel productsPage = new ProductsPageViewModel
            {
                Products = new List<Product>(),
                PageParams = new PageViewModel
                {
                    CurrentPage = 1,
                    TotalPages = 3
                },
                SearchBarParams = new SearchBarViewModel
                {
                    manufacturers = new List<Manufacturer>(),
                    pageParams = pageParams
                }
            };
            return View(productsPage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
