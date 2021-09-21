using BookLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Business
{
    class FilterActions : IFilterActions
    {
        // A class dedicated to different filtering types
        BookActions bookActions = new();
        public List<Book> FilterByAuthor(string author)
        {
            List<Book> books = bookActions.GetBookList();
            return books.FindAll(book => book.Author == author).ToList();
        }

        public List<Book> FilterByAvailability(string availability)
        {
            List<Book> books = bookActions.GetBookList();
            if (availability.StartsWith("a"))
            {
                return books.FindAll(book => book.Taken == false).ToList();
            } else if (availability.StartsWith("t"))
            {
                return books.FindAll(book => book.Taken == true).ToList();
            } else
            {
                return new List<Book>();
            }
        }

        public List<Book> FilterByCategory(string category)
        {
            List<Book> books = bookActions.GetBookList();
            return books.FindAll(book => book.Category == category).ToList();
        }

        public List<Book> FilterByISBN(string isbn)
        {
            List<Book> books = bookActions.GetBookList();
            return books.FindAll(book => book.Isbn == isbn).ToList();
        }

        public List<Book> FilterByLanguage(string language)
        {
            List<Book> books = bookActions.GetBookList();
            return books.FindAll(book => book.Language == language).ToList();
        }

        public List<Book> FilterByName(string name)
        {
            List<Book> books = bookActions.GetBookList();
            return books.FindAll(book => book.Name == name).ToList();
        }

        public List<Book> NoFilter()
        {
            return bookActions.GetBookList();
        }
    }
}
