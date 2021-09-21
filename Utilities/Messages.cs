using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Utilities
{
    static class Messages
    {
        // A class dedicated to UI messages
        public static string CommandMenu = "------------------------------------" +
                "\nAvailable actions:   \n1 - add a book" +
                                        "\n2 - take a book" +
                                        "\n3 - return a book" +
                                        "\n4 - view all books" +
                                        "\n5 - delete a book" +
                                        "\n0 - exit" +
                                        "\nEnter preferred command's number: ";
        // Not found
        public static string NoBooks = "No books were found.";
        public static string NoBook = "Number is not in given range.";
        public static string NoFilter = "Filter not found.";
        // Limits
        public static string ExceedeLimit = "Exceeded max book limit.";
        public static string MaxDayLimit = "Max day number: 60";
        public static string MinDayLimit = "Min day number: 1";
        // Validation 
        public static string NotAvailableCommand = "Please enter an available commands's number.";
        public static string IllegalAnswer = "Illegal answer.";
        public static string NotInteger = "Please enter a number.";
        // Confirmation
        public static string BookAdded = "\nBook is added.\n";
        public static string BookTaken = "\nBook taken successfully.\n";
        public static string BookDeleted = "\nBook is deleted.\n";



    }
}
