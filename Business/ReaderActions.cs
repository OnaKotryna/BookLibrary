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
        // A class dedicated to readers commands
        JsonHandler jsonHandler = new JsonHandler();

        private static string fileName = "ReaderBank.json";
        public string ReturnBook(int readerId, int bookNr)
        {
            string message = "Book returned";
            Reader reader = GetReader(readerId, bookNr);
            int readerIndex = GetReaderIndex(readerId, bookNr);
            DateTime deadline = reader.DateTaken.AddDays(reader.DayNumber);
            if (deadline < DateTime.UtcNow.Date)
            {
                message = "Oh my fur and whiskers! I'm late, I'm late, I'm late!";
            }
            jsonHandler.DeleteItem<Reader>(readerIndex, fileName);
            return message;
        }

        public void TakeBook(Reader reader)
        {
            jsonHandler.AddItem<Reader>(reader, fileName);
        }

        public List<Reader> GetReaderBooks(int readerId)
        {
            List<Reader> books = jsonHandler.ReadItemBank<Reader>(fileName);
            return books.FindAll(reader => reader.ReaderId == readerId).ToList();
        }

        public int GetReaderIndex(int readerId, int bookId)
        {
            List<Reader> readers = jsonHandler.ReadItemBank<Reader>(fileName).ToList();
            foreach (var reader in readers)
            {
                if (reader.ReaderId == readerId && reader.BookId == bookId)
                {
                    return readers.IndexOf(reader);
                }
            }
            return -1;
        }

        public Reader GetReader(int readerId, int bookId)
        {
            List<Reader> readers = jsonHandler.ReadItemBank<Reader>(fileName).ToList();
            foreach (var reader in readers)
            {
                if (reader.ReaderId == readerId && reader.BookId == bookId)
                {
                    return reader;
                }
            }
            return new Reader();
        }


    }
}
