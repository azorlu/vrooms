using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vrooms.Domain.Abstract;
using Vrooms.Domain.Entities;
using Vrooms.WebUI.Models;

namespace Vrooms.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IBookRepository repository; 

        public CartController(IBookRepository bookRepository)
        {
            repository = bookRepository;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int bookId, string returnUrl)
        {
            Book book = repository.Books
            .FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                cart.AddItem(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int bookId, string returnUrl)
        {
            Book book = repository.Books
            .FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                cart.RemoveItem(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult CartSummary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}