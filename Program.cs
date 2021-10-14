using BookLibrary.Business;
using BookLibrary.Entities;
using BookLibrary.Utilities;
using System;
using System.Collections.Generic;

namespace BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Visma's Library");

            int command = -1;
            BookActions bookActions = new();
            ReaderActions readerActions = new();

            while (command != 0)
            {
                // Printing command menu and getting user's preferred command
                Console.WriteLine(Messages.CommandMenu);
                string commandStr = Console.ReadLine();
                if (Int32.TryParse(commandStr, out command))
                {
                    switch (command)
                    {
                        case 1:
                            // Command to add a new book.
                            Console.WriteLine("----------------------\nAdd a Book\n");
                            //Getting book's data
                            Book book = GetBooksData();
                            bookActions.AddBook(book);
                            Console.WriteLine(Messages.BookAdded);
                            break;

                        case 2:
                            // Command to take a book from the library.
                            Console.WriteLine("----------------------\nTake a Book\n");
                            // Getting reader's data
                            Reader reader = new();
                            Console.WriteLine("Choose book to take:");

                            List<Book> books = GetFilteredList((int)Filters.None);
                            PrintSimplifiedBookList(books);

                            // Choosing preferred book 
                            Console.WriteLine("\nEnter book's number: ");
                            string bookNr = Console.ReadLine();

                            // Check if number
                            if(Int32.TryParse(bookNr, out int parsedNr)){
                                reader.BookId = parsedNr;

                                // Check if there is a book with given number
                                if (reader.BookId > books.Count || reader.BookId < 0)
                                {
                                    Console.WriteLine(Messages.NoBook);
                                    break;
                                } else if (books[reader.BookId].Taken)  // check if a book is taken
                                {
                                    Console.WriteLine("Book is taken.");
                                    break;
                                }

                                // Id to distinguish readers
                                Console.WriteLine("Enter Your ID: ");
                                string enteredId = Console.ReadLine();

                                // Check if number
                                if (Int32.TryParse(enteredId, out int parsedId))
                                {
                                    reader.ReaderId = parsedId;
                                    List<Reader> readerBooks = readerActions.GetReaderBooks(reader.ReaderId);
                                    if (readerBooks.Count >= 3) // Validates 3 books max
                                    {
                                        Console.WriteLine(Messages.ExceedeLimit);
                                        break;
                                    }
                                    // Specifying period
                                    Console.WriteLine("Enter day number: ");
                                    string enteredDays = Console.ReadLine();

                                    // Check if number
                                    if (Int32.TryParse(enteredDays, out int parsedDays))
                                    {
                                        reader.DayNumber = parsedDays;
                                        while (reader.DayNumber > 60 || reader.DayNumber <= 0)       // Validates 60 days max
                                        {
                                            if (reader.DayNumber > 60)
                                            {
                                                Console.WriteLine(Messages.MaxDayLimit);
                                            }
                                            else if (reader.DayNumber <= 0)
                                            {
                                                Console.WriteLine(Messages.MinDayLimit);
                                            }
                                            reader.DayNumber = Int32.Parse(Console.ReadLine());
                                        }
                                        reader.DateTaken = DateTime.UtcNow.Date;
                                        // saving collected data
                                        readerActions.TakeBook(reader);
                                        bookActions.TakeBook(reader.BookId);
                                        Console.WriteLine(Messages.BookTaken);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(Messages.NotInteger);
                                    }
                                } 
                                else
                                {
                                    Console.WriteLine(Messages.NotInteger);
                                }
                            } 
                            else
                            {
                                Console.WriteLine(Messages.NotInteger);
                            }
                            break;

                        case 3:
                            // Command to return a book.
                            Console.WriteLine("----------------------\nReturn a Book\n");

                            Console.WriteLine("Enter Your ID:");
                            
                            string givenId = Console.ReadLine();
                            bool readerExist = false;
                            if(Int32.TryParse(givenId, out int parsedGivenId))
                            {
                                int readerId = parsedGivenId;
                                List<Reader> rBooks = readerActions.GetReaderBooks(readerId);

                                // Check if reader exist
                                foreach (var r in rBooks)
                                {
                                    if (r.ReaderId == readerId)
                                    {
                                        readerExist = true;
                                        break;
                                    }
                                }
                                if (readerExist)
                                {
                                    Console.WriteLine("Which book do you want to return?");
                                    PrintSimplifiedBookList(GetFilteredList((int)Filters.None));
                                    int bookToReturn = AskForBookNr();
                                    // checking if the chosen book is taken by reader
                                    if(rBooks.FindAll(x => x.ReaderId == readerId && x.BookId == bookToReturn).Count == 1)
                                    {
                                        if(readerActions.ReturnBook(readerId, bookToReturn) == 0)
                                        {
                                            Console.WriteLine(Messages.ReturnMessage);
                                        } else if(readerActions.ReturnBook(readerId, bookToReturn) == 1)
                                        {
                                            Console.WriteLine(Messages.LateReturnMessage);
                                        }
                                        bookActions.ReturnBook(bookToReturn);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Book is not taken by you.");
                                    }
                                } else
                                {
                                    Console.WriteLine("Reader not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine(Messages.NotInteger);
                            }
                            break;
                        case 4:
                            // Command to list all the books.
                            Console.WriteLine("----------------------\nView Books\n");

                            Console.WriteLine("Available filters:");
                            foreach (Filters filter in Enum.GetValues(typeof(Filters)))
                            {
                                Console.WriteLine((int)filter + ". " + filter);
                            }
                            Console.WriteLine("\nEnter preferred filter's number:");
                            int filterType = Int32.Parse(Console.ReadLine());

                            List<Book> filteredList = GetFilteredList(filterType);
                            if (filteredList.Count > 0)
                            {
                                Console.WriteLine("Books:\n");
                                PrintFilteredBookList(filteredList);
                            }
                            else
                            {
                                Console.WriteLine(Messages.NoBooks);
                            }
                            break;

                        case 5:
                            // Command to delete a book.
                            Console.WriteLine("----------------------\nDelete a Book\n");
                            PrintSimplifiedBookList(GetFilteredList((int)Filters.None)); 
                            int nr = AskForBookNr();
                            int result = bookActions.DeleteBook(nr);
                            // check if deleted or not
                            if(result == 1)
                            {
                                Console.WriteLine("Book deleted.");
                            } 
                            else
                            {
                                Console.WriteLine("Book is taken. Cannot be deleted.");
                            }
                            break;

                        default:
                            Console.WriteLine(Messages.NotAvailableCommand);
                            break;
                    }
                }
                else
                {
                    command = -1;
                    Console.WriteLine(Messages.NotAvailableCommand);
                }
            }

            // Exiting app
            Console.WriteLine("\nExiting Library");
        }

        private static List<Book> GetFilteredList(int filterType)
        {
            FilterActions filterActions = new();
            switch (filterType)
            {
                case (int)Filters.None:
                    return filterActions.NoFilter();

                case (int)Filters.Author:
                    Console.WriteLine("Enter author:");
                    string authorName = Console.ReadLine();
                    return filterActions.FilterByAuthor(authorName);

                case (int)Filters.Name:
                    Console.WriteLine("Enter name:");
                    string bookName = Console.ReadLine();
                    return filterActions.FilterByName(bookName);

                case (int)Filters.Category:
                    Console.WriteLine("Enter category:");
                    string category = Console.ReadLine();
                    return filterActions.FilterByCategory(category);

                case (int)Filters.ISBN:
                    Console.WriteLine("Enter ISBN:");
                    string isbn = Console.ReadLine();
                    return filterActions.FilterByISBN(isbn);

                case (int)Filters.Language:
                    Console.WriteLine("Enter language:");
                    string language = Console.ReadLine();
                    return filterActions.FilterByLanguage(language);

                case (int)Filters.Availability:
                    Console.WriteLine("Enter availability: \nt - taken\na - available");
                    string availability = Console.ReadLine();
                    if(availability.StartsWith('t') || availability.StartsWith('a'))
                    {
                        return filterActions.FilterByAvailability(availability);
                    } else
                    {
                        Console.WriteLine(Messages.IllegalAnswer);
                        break;
                    }
                default:
                    Console.WriteLine(Messages.NoFilter);
                    break;
            }
            return new List<Book>();
        }

        private static void PrintFilteredBookList(List<Book> books)
        {
            string datePattern = "yyyy-MM-dd";
            foreach (var bk in books)
            {
                Console.WriteLine("Name: {0}" +
                    "\nAuthor: {1}" +
                    "\nCategory: {2}" +
                    "\nLanguage: {3}" +
                    "\nPublication date: {4}" +
                    "\nISBN: {5}\n", bk.Name, bk.Author, bk.Category, bk.Language, bk.Published.ToString(datePattern), bk.Isbn);
            }
        }
        
        private static Book GetBooksData()
        {
            Book book = new Book();
            string datePattern = "yyyy-MM-dd";

            Console.WriteLine("Name: ");
            book.Name = Console.ReadLine();
            Console.WriteLine("Author: ");
            book.Author = Console.ReadLine();
            Console.WriteLine("Category: ");
            book.Category = Console.ReadLine();
            Console.WriteLine("Language: ");
            book.Language = Console.ReadLine();
            Console.WriteLine("Publication date: \nformat: " + datePattern);
            book.Published = DateTime.ParseExact(Console.ReadLine(), datePattern, null);
            Console.WriteLine("ISBN: ");
            book.Isbn = Console.ReadLine();

            return book;
        }

        private static void PrintSimplifiedBookList(List<Book> books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                string bookLine = String.Format("{0}. {1}, ", i, books[i].Name);
                bookLine = books[i].Taken ? String.Concat(bookLine, "taken") : String.Concat(bookLine, "available");
                Console.WriteLine(bookLine);
            }
        }

        private static int AskForBookNr()
        {
            Console.WriteLine("Enter book number:");
            return Int32.Parse(Console.ReadLine());
        }
        
    }
}
