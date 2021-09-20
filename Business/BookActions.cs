using BookLibrary.Data;
using BookLibrary.Entities;
using BookLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Business
{
    class BookActions : IBookActions
    {
        JsonHandler jsonHandler = new JsonHandler();
        public void AddBook(Book book)
        {
            jsonHandler.AddBook(book);
        }

        public void DeleteBook(int nr)
        {
            jsonHandler.DeleteBook(nr);
        }

        public void ReturnBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Book TakeBook()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBookList()
        {
            List<Book> books = jsonHandler.ReadBookBank();
            return books;
        }

    }
}
