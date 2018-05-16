using Microsoft.AspNetCore.Mvc;
using SSCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCore.Components
{
    public class NavigationMenuViewComponent :ViewComponent
    {
        IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products.
                Select(x => x.Category).
                Distinct().
                OrderBy(x => x));

        }
    }
}
