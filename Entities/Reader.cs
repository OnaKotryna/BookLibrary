using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Entities
{
    class Reader
    {
        private int readerId;
        private int bookId;
        private double dayNumber;
        private DateTime dateTaken;

        public int ReaderId { get => readerId; set => readerId = value; }
        public double DayNumber { get => dayNumber; set => dayNumber = value; }
        public DateTime DateTaken { get => dateTaken; set => dateTaken = value; }
        public int BookId { get => bookId; set => bookId = value; }
    }
}
