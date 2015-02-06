using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vrooms.Domain.Abstract;
using Vrooms.Domain.Entities;
using Vrooms.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Vrooms.UnitTests
{
    [TestClass]
    public class CatalogControllerTests
    {
        Mock<IBookRepository> mock = null;
        Mock<ILanguageRepository> mockLanguages = null;
        CatalogController controller = null;

        [TestInitialize]
        public void TestInit()
        {
            mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
                new Book {BookId = 1, Title = "Book 1", LanguageId=1},
                new Book {BookId = 2, Title = "Book 2", LanguageId=1},
                new Book {BookId = 3, Title = "Book 3", LanguageId=1}
            });

            mockLanguages = new Mock<ILanguageRepository>();
            mockLanguages.Setup(m => m.Languages).Returns(new Language[] {
                new Language {LanguageId = 1, LanguageName_En = "English"},
                new Language {LanguageId = 2, LanguageName_En = "French"}
            });

            controller = new CatalogController(mock.Object, mockLanguages.Object);
           
        }

        [TestMethod]
        public void Should_Contain_All_Books()
        {
            // Action
            Book[] booksArray = ((IEnumerable<Book>)controller.Index().ViewData.Model).ToArray();
            // Assert
            Assert.IsTrue(booksArray.Length == 3);
            Assert.AreEqual(booksArray[0].Title, "Book 1");
            Assert.AreEqual(booksArray[1].Title, "Book 2");
            Assert.AreEqual(booksArray[2].Title, "Book 3");
        }

        [TestMethod]
        public void Should_Edit_Present_Book()
        {
            Book book1 = controller.Edit(1).ViewData.Model as Book;
            Book book2 = controller.Edit(2).ViewData.Model as Book;
            Book book3 = controller.Edit(3).ViewData.Model as Book;

            Assert.AreEqual(1, book1.BookId);
            Assert.AreEqual(2, book2.BookId);
            Assert.AreEqual(3, book3.BookId);
        }

        [TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        public void Should_Not_Edit_Absent_Book()
        {
            Book book4 = controller.Edit(4).ViewData.Model as Book;

            Assert.IsNull(book4);
        }

        [TestMethod]
        public void Should_Save_Valid_Changes()
        {
            Book book = new Book { BookId = 1, Title = "Book 1", LanguageId = 1 };
            
            ActionResult result = controller.Edit(book);
            
            mock.Verify(m => m.SaveBook(book));
           
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Should_Not_Save_Invalid_Changes()
        {
            Book book = new Book { BookId = 1, Title = "Book 1", LanguageId = 1 };
            
            controller.ModelState.AddModelError("error", "error");
            
            ActionResult result = controller.Edit(book);

            mock.Verify(m => m.SaveBook(It.IsAny<Book>()), Times.Never());

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Should_Delete_Present_Book()
        {
            controller.Delete(2);
            mock.Verify(m => m.DeleteBook(2));
        }
    }
}
