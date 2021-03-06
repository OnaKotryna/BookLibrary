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
        // A class dedicated to book commands
        JsonHandler jsonHandler = new JsonHandler();

        private static string fileName = "BookBank.json";
        public void AddBook(Book book)
        {
            jsonHandler.AddItem<Book>(book, fileName);
        }

        public int DeleteBook(int bookNr)
        {
            List<Book> books = GetBookList();
            if (books[bookNr].Taken)
            {
                return -1;
            } else
            {
                jsonHandler.DeleteItem<Book>(bookNr, fileName);
                return 1;
            }
        }

        public void ReturnBook(int bookNr)
        {
            List<Book> books = jsonHandler.ReadItemBank<Book>(fileName);
            books.ElementAt(bookNr).Taken = false;
            jsonHandler.SaveFile<Book>(books, fileName);
        }

        public void TakeBook(int id)
        {
            List<Book> books = jsonHandler.ReadItemBank<Book>(fileName);
            books.ElementAt(id).Taken = true;
            jsonHandler.SaveFile<Book>(books, fileName);
        }

        public List<Book> GetBookList()
        {
            List<Book> books = jsonHandler.ReadItemBank<Book>(fileName);
            return books;
        }

    }
}
