using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vrooms.Domain.Abstract;
using Vrooms.Domain.Entities;
using Vrooms.WebUI.Controllers;
using Vrooms.WebUI.Models;
using Vrooms.WebUI.HtmlHelpers;


namespace Vrooms.UnitTests
{
    [TestClass]
    public class CartControllerTests
    {
        Mock<IBookRepository> mock = null;
        Cart cart = null;
        Book book1 = null;
        Book book2 = null;
        Book book3 = null;
        CartController controller = null;
        
        [TestInitialize]
        public void TestInit()
        {
            mock = new Mock<IBookRepository>();
            cart = new Cart();
            book1 = new Book {BookId = 1, Title = "Book 1", LanguageId=1};
            book2 = new Book {BookId = 2, Title = "Book 2", LanguageId=1};
            book3 = new Book {BookId = 3, Title = "Book 3", LanguageId=1 };

            mock.Setup(m => m.Books).Returns(new Book[] {book1, book2, book3}.AsQueryable());
            controller = new CartController(mock.Object);
        }

        [TestMethod]
        public void Should_Add_New_Items()
        {
            cart.AddItem(book1);
            cart.AddItem(book2);
            cart.AddItem(book3);
            CartItem[] cartItems = cart.Items.ToArray();

            Assert.AreEqual(cartItems.Length, 3);
            Assert.AreEqual(cartItems[0].Book, book1);
            Assert.AreEqual(cartItems[1].Book, book2);
            Assert.AreEqual(cartItems[2].Book, book3);
        }

        [TestMethod]
        public void Should_Add_Books_Only_Once()
        {
            cart.AddItem(book1);
            cart.AddItem(book2);
            cart.AddItem(book1);
            CartItem[] cartItems = cart.Items.ToArray();

            Assert.AreEqual(cartItems.Length, 2);
            Assert.AreEqual(cartItems[0].Book, book1);
            Assert.AreEqual(cartItems[1].Book, book2);
        }

        [TestMethod]
        public void Should_Remove_Items()
        {
            cart.AddItem(book1);
            cart.AddItem(book2);
            cart.AddItem(book3);
            cart.RemoveItem(book2);
            CartItem[] cartItems = cart.Items.ToArray();

            Assert.AreEqual(cartItems.Length, 2);
            Assert.AreEqual(cartItems[0].Book, book1);
            Assert.AreEqual(cartItems[1].Book, book3);
        }

        [TestMethod]
        public void Should_Clear_Items()
        {
            cart.AddItem(book1);
            cart.AddItem(book2);
            cart.AddItem(book3);
            cart.Clear();
            CartItem[] cartItems = cart.Items.ToArray();

            Assert.AreEqual(cartItems.Length, 0);
           
        }

        [TestMethod]
        public void Should_Add_New_Items_To_Cart_Controller()
        {
            controller.AddToCart(cart, book1.BookId, null);
            controller.AddToCart(cart, book2.BookId, null);
            controller.AddToCart(cart, book3.BookId, null);

            Assert.AreEqual(cart.Items.Count(), 3);
            Assert.AreEqual(cart.Items.ToArray()[0].Book.BookId, book1.BookId);
        }

        [TestMethod]
        public void Should_Go_To_Cart_Contents_List_After_Adding_Book()
        {
            RedirectToRouteResult result = controller.AddToCart(cart, book1.BookId, "testUrl");

            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "testUrl");
        }

        [TestMethod]
        public void Should_Display_Cart_Contents()
        {
            CartIndexViewModel viewModel = (CartIndexViewModel)controller.Index(cart, "testUrl").ViewData.Model;
            
            Assert.AreSame(viewModel.Cart, cart);
            Assert.AreEqual(viewModel.ReturnUrl, "testUrl");
        }
    }
}
