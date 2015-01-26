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
    public class BookController : Controller
    {
        private IBookRepository repository;
        public int PageSize = 2;

        public BookController(IBookRepository bookRepository)
        {
            this.repository = bookRepository;   
        }

        public ViewResult List(int? langId, int pageNum = 1)
        {
            BooksListViewModel viewModel = new BooksListViewModel { 
                Books = repository.Books
                .Where(b => langId == null || b.LanguageId == langId)
                    .OrderBy(b => b.BookId)
                    .Skip((pageNum-1) * PageSize)
                    .Take(PageSize),
                Pagination = new Pagination { 
                    CurrentPageNum = pageNum, 
                    ItemsPerPage = PageSize, 
                    TotalItems = repository.Books.Count()
                },
                CurrentLanguageId = langId 
            };
            

            return View(viewModel);
        }
    }
}