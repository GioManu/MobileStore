using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Views.Shared.Components.SearchBar
{
    public class SearchBarViewComponent : ViewComponent
    {
        public SearchBarViewComponent() { }
        public IViewComponentResult Invoke(SearchBarViewModel searchBarViewModel)
        {
            return View(searchBarViewModel);
        }
    }


}
