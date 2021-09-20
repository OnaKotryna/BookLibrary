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
        public void ReturnBook();
        public List<Reader> GetReaderBooks(Reader reader);
    }
}
