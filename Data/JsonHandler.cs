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
        // A class that works with data file
        private static string path = @"C:\Users\Ona Kotryna\source\repos\BookLibrary\Data";

        public void AddItem<T>(T item, string fileName)
        {
            List<T> items = ReadItemBank<T>(fileName);
            items.Add(item);
            SaveFile<T>(items, fileName);
        }

        // Reads all file (gets all elements)
        public List<T> ReadItemBank<T>(string fileName)
        {
            List<T> items;
            string fullPath = Path.Combine(path, fileName);
            string json = File.ReadAllText(fullPath);
            items = JsonConvert.DeserializeObject<List<T>>(json);
            return items;
        }

        public void DeleteItem<T>(int itemNr, string fileName)
        {
            List<T> items = ReadItemBank<T>(fileName);
            items.RemoveAt(itemNr);
            SaveFile<T>(items, fileName);
        }
        public void SaveFile<T>(List<T> items, string fileName)
        {
            string fullPath = Path.Combine(path, fileName);
            File.WriteAllText(fullPath, JsonConvert.SerializeObject(items));
        }
    }
}
