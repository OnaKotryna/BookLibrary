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

        public Book() { }
        public Book(string name, string author, string category, string language, DateTime published, string isbn)
        {
            this.Name = name;
            this.Author = author;
            this.Category = category;
            this.Language = language;
            this.Published = published;
            this.Isbn = isbn;
        }

        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string Category { get => category; set => category = value; }
        public string Language { get => language; set => language = value; }
        public DateTime Published { get => published; set => published = value; }
        public string Isbn { get => isbn; set => isbn = value; }
    }
}
