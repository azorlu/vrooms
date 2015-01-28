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

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public RedirectToRouteResult AddToCart(int bookId, string returnUrl)
        {
            Book book = repository.Books
            .FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                GetCart().AddItem(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int bookId, string returnUrl)
        {
            Book book = repository.Books
            .FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                GetCart().RemoveItem(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


    }
}