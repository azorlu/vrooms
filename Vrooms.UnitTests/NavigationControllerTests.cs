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
    public class NavigationControllerTests
    {
        Mock<IBookRepository> mock = null;
        NavigationController controller = null;
        
        [TestInitialize]
        public void TestInit()
        {
            mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
                new Book {BookId = 1, Title = "Book 1", LanguageId=1},
                new Book {BookId = 2, Title = "Book 2", LanguageId=1},
                new Book {BookId = 3, Title = "Book 3", LanguageId=1},
                new Book {BookId = 4, Title = "Book 4", LanguageId=2},
                new Book {BookId = 5, Title = "Book 5", LanguageId=2},
                new Book {BookId = 5, Title = "Book 6", LanguageId=3}
            });

            controller = new NavigationController(mock.Object);
            
        }

        [TestMethod]
        public void Should_Create_Languages()
        {
            string[] languages = ((IEnumerable<string>)controller.Menu().Model).ToArray();
            Assert.IsTrue(languages.Length == 3);
            //Assert.AreEqual(languages[0], "English");
            //Assert.AreEqual(languages[1], "French");
            //Assert.AreEqual(languages[2], "German");

        }

    }
}
