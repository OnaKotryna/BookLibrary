using BookLibrary.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookLibrary.Data
{
    public class JsonHandler
    {

        private static string path = @"C:\Users\Ona Kotryna\source\repos\BookLibrary\Data";
        private static string fileName = "BookBank.json";
        private string fullPath = Path.Combine(path, fileName);

        public void AddBook(Book book)
        {
            List<Book> books = ReadBookBank();
            books.Add(book);

            File.WriteAllText(fullPath, JsonConvert.SerializeObject(books));
        }

        public List<Book> ReadBookBank()
        {
            List<Book> books;
            string json = File.ReadAllText(fullPath);
            books = JsonConvert.DeserializeObject<List<Book>>(json);
            return books;
        }
    }
}
