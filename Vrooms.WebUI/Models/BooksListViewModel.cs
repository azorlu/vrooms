using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vrooms.Domain.Entities;

namespace Vrooms.WebUI.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public Pagination Pagination { get; set; }
    }
}