using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vrooms.Domain.Abstract;
using Vrooms.Domain.Entities;
using Vrooms.WebUI.Models;

namespace Vrooms.WebUI.Controllers
{
    public class CatalogController : Controller
    {
        private IBookRepository bookRepository;
        private ILanguageRepository languageRepository;
        private List<SelectListItem> languagesList;

        public CatalogController(IBookRepository bookRepository, ILanguageRepository languageRepository)
        {
            this.bookRepository = bookRepository;
            this.languageRepository = languageRepository;
        }

        public ViewResult Index()
        {
            return View(bookRepository.Books);
        }

        //todo :: move languages list to its own controller
        private void OrganizeLanguagesList(Book book)
        {
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();
            int langId = book == null ? 1 : book.LanguageId;
            foreach (Language x in languageRepository.Languages)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = x.LanguageName_En,
                    Value = x.LanguageId.ToString(),
                    Selected = (x.LanguageId == langId)
                };
                listSelectListItems.Add(selectList);
            }
            //LanguagesListViewModel langListViewModel = new LanguagesListViewModel()
            //{
            //    LanguagesList = listSelectListItems
            //};
            languagesList = listSelectListItems;

            ViewBag.LanguagesList = languagesList;
        }
        public ViewResult Edit(int bookId)
        {
            Book book = bookRepository.Books.FirstOrDefault(b => b.BookId == bookId);
            OrganizeLanguagesList(book);
            
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bookRepository.SaveBook(book);
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

               TempData["message"] = string.Format("{0} has been saved.", book.Title);
               return RedirectToAction("Index");
            }
            else
            {
                OrganizeLanguagesList(book);
                return View(book);
            }
        }

        public ViewResult Create()
        {
            OrganizeLanguagesList(null);
            return View("Edit", new Book());
        }

        [HttpPost]
        public ActionResult Delete(int bookId)
        {
            Book deletedBook = bookRepository.DeleteBook(bookId);
            if (deletedBook != null)
            {
                TempData["message"] = string.Format("{0} has been deleted.", deletedBook.Title);
            }
            return RedirectToAction("Index");
        }

    }
}