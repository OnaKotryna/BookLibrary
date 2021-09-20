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
        public Book TakeBook();
        public void ReturnBook(Book book);
        public List<Book> GetBookList(Filters filter);
        public void DeleteBook(int nr);
    }
}
