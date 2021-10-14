using BookLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Business
{
    interface IReaderActions
    {
        public void TakeBook(Reader reader);
        public int ReturnBook(int readerId, int bookId);
        public List<Reader> GetReaderBooks(int readerId);
        public int GetReaderIndex(int readerId, int bookId);
        public Reader GetReader(int readerId, int bookId);
    }
}
