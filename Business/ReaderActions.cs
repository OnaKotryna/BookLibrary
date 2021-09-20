using BookLibrary.Data;
using BookLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Business
{
    class ReaderActions : IReaderActions
    {
        JsonHandler jsonHandler = new JsonHandler();

        private static string fileName = "ReaderBank.json";
        public void ReturnBook()
        {
            throw new NotImplementedException();
        }

        public void TakeBook(Reader reader)
        {
            jsonHandler.AddItem<Reader>(reader, fileName);
        }

        public List<Reader> GetReaderBooks(Reader reader)
        {
            List<Reader> books = jsonHandler.ReadItemBank<Reader>(fileName);
            return books.FindAll(reader => reader.ReaderId == reader.ReaderId).ToList();
        }
    }
}
