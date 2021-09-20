using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Entities
{
    class Reader
    {
        private string readerId;
        private int dayNumber;
        private DateTime dateTaken = DateTime.Now;
        private int bookId;

        public string ReaderId { get => readerId; set => readerId = value; }
        public int DayNumber { get => dayNumber; set => dayNumber = value; }
        public DateTime DateTaken { get => dateTaken; }
        public int BookId { get => bookId; set => bookId = value; }
    }
}
