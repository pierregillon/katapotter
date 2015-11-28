using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter.Test.Domain
{
    public class Basket
    {
        private readonly List<BookSet> _bookSets = new List<BookSet>();

        public decimal Price
        {
            get { return _bookSets.Sum(bookSet => bookSet.Price); }
        }

        public void AddBook(Book book)
        {
            if (book == null) {
                throw new ArgumentNullException("book");
            }
            var availableBookSet = GetFirstAvailableBookSet(book);
            if (availableBookSet == null) {
                availableBookSet = new BookSet();
                _bookSets.Add(availableBookSet);
            }
            availableBookSet.AddBook(book);
        }

        private BookSet GetFirstAvailableBookSet(Book book)
        {
            if (book == null) {
                throw new ArgumentNullException("book");
            }
            return _bookSets.FirstOrDefault(bookSet => bookSet.Contains(book) == false);
        }
    }
}