﻿using System;
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

        public ViewResult List(string category, int productPage =1)
        {
            ProductsListViewModel plm = new ProductsListViewModel();
            PagingInfo pi = new PagingInfo();
            plm.Products= repository.Products.Where(p=> category==null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize);
            pi.CurrentPage = productPage;
            pi.ItemsPerPage = PageSize;
            if (category == null)
                pi.TotalItems = repository.Products.Count();
            else
                pi.TotalItems = repository.Products.Where(p => p.Category == category).Count();

            plm.PagingInfo = pi;
            plm.CurrentCategory = category;

            return View(plm);

        }
    }
}