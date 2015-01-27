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
        Mock<ILanguageRepository> mock = null;
        NavigationController controller = null;

        Mock<IBookRepository> mockBooks = null;
        
        [TestInitialize]
        public void TestInit()
        {
            // mocking navigation property
            mockBooks = new Mock<IBookRepository>();
            mockBooks.Setup(m => m.Books).Returns(new Book[] {
                new Book {BookId = 1, Title = "Book 1", LanguageId=1},
                new Book {BookId = 2, Title = "Book 2", LanguageId=2}
            });

            mock = new Mock<ILanguageRepository>();
            mock.Setup(m => m.Languages).Returns(new Language[] {
                new Language {LanguageId = 1, LanguageName_En = "English"},
                new Language {LanguageId = 2, LanguageName_En = "French"}
            });

            Language[] langs = mock.Object.Languages.ToArray();
            Book[] books = mockBooks.Object.Books.ToArray();
            langs[0].Books = new Book[] {books[0]};
            langs[1].Books = new Book[] {books[1]};
            
            controller = new NavigationController(mock.Object);

        }

        [TestMethod]
        public void Should_Create_Languages()
        {
            Language[] languages = ((IEnumerable<Language>)controller.Menu().Model).ToArray();
            Assert.IsTrue(languages.Length == 2);
            Assert.AreEqual(languages[0].LanguageName_En, "English");
            Assert.AreEqual(languages[1].LanguageName_En, "French");
        }

        [TestMethod]
        public void Should_Indicate_Selected_Language()
        {
            int? langId = 2;

            int selLangId = controller.Menu(langId).ViewBag.SelectedLanguageId;

            Assert.AreEqual(langId, selLangId);
        }

    }
}
