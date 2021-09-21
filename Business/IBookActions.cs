using BookLibrary.Entities;
using BookLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Business
{
    public interface IBookActions
    {
        public void AddBook(Book book);
        public void TakeBook(int bookNr);
        public void ReturnBook(int bookNr);
        public List<Book> GetBookList();
        public int DeleteBook(int nr);
    }
}
