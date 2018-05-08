using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSCore.Models;
using SSCore.Models.ViewModels;

namespace SSCore.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Product")]
    public class ProductController : Controller
    {
        IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int productPage =1)
        {
            ProductsListViewModel plm = new ProductsListViewModel();
            PagingInfo pi = new PagingInfo();
            plm.Products= repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize);
            pi.CurrentPage = productPage;
            pi.ItemsPerPage = PageSize;
            pi.TotalItems = repository.Products.Count();
            plm.PagingInfo = pi;

            return View(plm);

        }
    }
}