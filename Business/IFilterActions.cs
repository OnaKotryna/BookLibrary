using BookLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Business
{
    interface IFilterActions
    {
        public List<Book> FilterByAuthor(string author);
        public List<Book> FilterByCategory(string category);
        public List<Book> FilterByLanguage(string language);
        public List<Book> FilterByISBN(string isbn);
        public List<Book> FilterByName(string name);
        //public List<Book> FilterByAvailability(int x);
    }
}
