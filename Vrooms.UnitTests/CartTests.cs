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
    public class CartTests
    {
        Cart cart = null;
        Book book1 = null;
        Book book2 = null;
        Book book3 = null;
        
        [TestInitialize]
        public void TestInit()
        {
            cart = new Cart();
            book1 = new Book {BookId = 1, Title = "Book 1", LanguageId=1};
            book2 = new Book {BookId = 2, Title = "Book 2", LanguageId=1};
            book3 = new Book {BookId = 3, Title = "Book 3", LanguageId=1 };
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
    }
}
