using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vrooms.Domain.Abstract;
using Vrooms.Domain.Entities;

namespace Vrooms.WebUI.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;

        public BookController(IBookRepository bookRepository)
        {
            this.repository = bookRepository;   
        }

        public ViewResult List()
        {
            return View(repository.Books);
        }
    }
}