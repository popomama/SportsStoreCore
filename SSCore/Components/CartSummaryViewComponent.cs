using Microsoft.AspNetCore.Mvc;
using SSCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCore.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
        Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
