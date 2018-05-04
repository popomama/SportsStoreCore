using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSCore.Models;

namespace SSCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
    }
}