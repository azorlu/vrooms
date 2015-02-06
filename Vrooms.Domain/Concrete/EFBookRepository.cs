using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vrooms.Domain.Abstract;
using Vrooms.Domain.Entities;

namespace Vrooms.Domain.Concrete
{
    public class EFBookRepository : IBookRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Book> Books
        {
            get { return context.Books;  }
        }

        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
            {
                context.Books.Add(book);
            }
            else
            {
                Book savedBook = context.Books.Find(book.BookId);
                if (savedBook != null)
                {
                    savedBook.Title = book.Title;
                    savedBook.Description = book.Description;
                    savedBook.ISBN = book.ISBN;
                    savedBook.Author = book.Author;
                    savedBook.LanguageId = book.LanguageId;
                    savedBook.PublicationYear = book.PublicationYear;
                    savedBook.Publisher = book.Publisher;
                }
            }

            context.SaveChanges();
        }

        public Book DeleteBook(int bookId)
        {
            Book deletedBook = context.Books.Find(bookId);
            if (deletedBook != null)
            {
                context.Books.Remove(deletedBook);
                context.SaveChanges();
            }

            return deletedBook;
        }
    }
}
