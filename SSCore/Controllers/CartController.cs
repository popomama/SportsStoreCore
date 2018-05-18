using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCore.Models;
using Microsoft.AspNetCore.Http;
using SSCore.Infrastructure;
using SSCore.Models.ViewModels;

namespace SSCore.Controllers
{
    public class CartController : Controller
    {
        IProductRepository repository;
        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if(product !=null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        public ViewResult Index(string returnUrl)
        {
            CartIndexViewModel vm = new CartIndexViewModel();
            vm.Cart = GetCart();
            vm.ReturnUrl = returnUrl;

            return View(vm);
        }
    }
}