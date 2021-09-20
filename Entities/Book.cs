using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Entities
{
    public class Book
    {
        private string name;
        private string author;
        private string category;
        private string language;
        private DateTime published;
        private string isbn;
        private bool taken = false;

        public Book() { }

        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string Category { get => category; set => category = value; }
        public string Language { get => language; set => language = value; }
        public DateTime Published { get => published; set => published = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public bool Taken { get => taken; set => taken = value; }
    }
}
