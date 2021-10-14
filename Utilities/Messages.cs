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

        // Title
        public static string LibraryTitle = "Book library";

        // Command menu
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
        public static string NoFilter = "Filter not found.";
        public static string NoReader = "Reader not found.";

        // Errors 
        public static string IncorrectBookError = "Book is not taken by you.";
        public static string TakenBookError = "Book is taken.";

        // Limits
        public static string ExceedeLimit = "Exceeded max book limit.";
        public static string MaxDayLimit = "Max day number: 60";
        public static string MinDayLimit = "Min day number: 1";
        public static string NoBook = "Number is not in given range.";

        // Validation 
        public static string NotAvailableCommand = "Please enter an available commands's number.";
        public static string IllegalAnswer = "Illegal answer.";
        public static string NotInteger = "Please enter a number.";


        // Confirmation
        public static string BookAdded = "\nBook is added.\n";
        public static string BookTaken = "\nBook is taken successfully.\n";
        public static string BookDeleted = "\nBook is deleted.\n";
        public static string ReturnMessage = "\nBook is returned\n";
        public static string LateReturnMessage = "\nOh my fur and whiskers! I'm late, I'm late, I'm late!\n";

        // Additional
        public static string ExitMessage = "\nExiting Library";
        public static string ListOfBooks = "List of books:";
        public static string AvailableFilters = "Available filters:";

        // Chosen Command UI messages
        public static string Tab = "----------------------";
        public static string AddBook = "\nAdd a Book\n";
        public static string TakeBook = "\nTake a Book\n";
        public static string ReturnBook = "\nReturn a Book\n";
        public static string ViewBooks = "\nView Books\n";
        public static string DeleteBooks = "\nDelete a Book\n";

        // Messages for getting data from the user
        public static string EnterAuthor = "Author:";
        public static string EnterName = "Name:";
        public static string EnterCategory = "Category:";
        public static string EnterISBN = "ISBN:";
        public static string EnterLanguage = "Language:";
        public static string EnterPublicationDate = "Publication date: \nformat: ";
        public static string EnterAvailability = "Enter availability: \nt - taken\na - available";
        public static string EnterBookNumber = "Enter book's number:";
        public static string EnterReadersId = "Enter your ID:";
        public static string EnterDayNumber = "Enter Day Number:";
        public static string EnterFilterNumber = "\nEnter preferred filter's number:";
        public static string AskForBookToReturn = "Which book do you want to return?";
    }
}
