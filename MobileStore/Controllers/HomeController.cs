using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileStore.DataModels;
using MobileStore.Helpers;
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

        private readonly int MaxPageSize = 6;
        public HomeController(ILogger<HomeController> logger,IProductRepository ProdRepo,IContentRepository ContentRepo,IManufacturerRepository ManuRepo)
        {
            _logger = logger;

            this.ProdRepo = ProdRepo;
            this.ContentRepo = ContentRepo;
            this.ManuRepo = ManuRepo;
        }

        public IActionResult Index(PageParametersViewModel pageParams)
        {
            List<Product> AllProds = this.ProdRepo.GetAll().ToList();

            ProductListHelper productHelper = new ProductListHelper(AllProds, ref pageParams,MaxPageSize);

            IEnumerable<Product> SelectedProds = productHelper.GetProdsBySearch();

            int TotalPages = productHelper.TotalPages();
           
            ProductsPageViewModel productsPage = new ProductsPageViewModel
            {
                Products = SelectedProds,
                PageParams = new PageViewModel
                {
                    TotalPages = TotalPages,
                    PageParams = pageParams
                },
                SearchBarParams = new SearchBarViewModel
                {
                    manufacturers = this.ManuRepo.GetAll().ToList(),
                    pageParams = pageParams
                }
            };
            return View(productsPage);
        }


        public IActionResult Product(int productId)
        {
            Product selectedProd = this.ProdRepo.GetByID(productId);

            ProductViewModel prodModel = new ProductViewModel
            {
                product = selectedProd,
                Carousel = new CarouselViewModel
                {
                    Images = selectedProd.Images,
                    VideoUrl = selectedProd.VideoUrl
                }
            };

            return View(prodModel);
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
