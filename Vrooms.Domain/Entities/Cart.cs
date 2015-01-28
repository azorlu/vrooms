using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vrooms.Domain.Entities
{
    public class Cart
    {
        private List<CartItem> cartItems = new List<CartItem>();
        // TODO :: move this value to app settings
        private static int MaxNumOfLoans = 10; 
        public void AddItem(Book book)
        {
            // A book might be added to the cart only if it is not added yet
            // There is a limit to the number of books that can be checked out at once
            CartItem item = cartItems
            .Where(x => x.Book.BookId == book.BookId)
            .FirstOrDefault();
            if (item == null && cartItems.Count <= MaxNumOfLoans)
            {
                cartItems.Add(new CartItem
                {
                    Book = book
                });
            }
        }

        public void RemoveItem(Book book)
        {
            cartItems.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public void Clear()
        {
            cartItems.Clear();
        }
        public IEnumerable<CartItem> Items
        {
            get { return cartItems; }
        }
    }

    public class CartItem
    {
        public Book Book { get; set; }
    }
}
