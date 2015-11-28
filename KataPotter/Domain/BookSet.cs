using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter.Test.Domain
{
    public class BookSet
    {
        private readonly List<Book> _books = new List<Book>();
        private readonly DiscountCatalog _discountCatalog = new DiscountCatalog();

        public decimal Price
        {
            get
            {
                var price = _books.Sum(book => book.Price);
                var numberOfDifferentBooks = _books.GroupBy(book => book.VolumeNumber).Count();
                return price*(1 - _discountCatalog.GetDiscount(numberOfDifferentBooks));
            }
        }

        public void AddBook(Book book)
        {
            if (book == null) {
                throw new ArgumentNullException("book");
            }
            _books.Add(book);
        }
        public bool Contains(Book book)
        {
            if (book == null) {
                throw new ArgumentNullException("book");
            }
            return _books.Contains(book);
        }
    }
}