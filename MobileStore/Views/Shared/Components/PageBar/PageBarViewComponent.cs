using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Views.Shared.Components
{
    public class PageBarViewComponent : ViewComponent
    {
        public PageBarViewComponent() { }

        public IViewComponentResult Invoke(PageViewModel pageViewModel)
        {
            return View(pageViewModel);
        }
    }
}
