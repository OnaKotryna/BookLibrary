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
            string actionString = "------------------------------------" +
                "\nAvailable actions:   \n1 - add a book" +
                                        "\n2 - take a book" +
                                        "\n3 - return a book" +
                                        "\n4 - view all books" +
                                        "\n5 - delete a book" +
                                        "\n0 - exit" +
                                        "\nEnter preferred action's number: ";

            Console.WriteLine(actionString);
            int action = Int32.Parse(Console.ReadLine());

            if (Validation.CheckInt(action))
            {
                BookActions bookActions = new();
                while (action != 0)
                { 
                    switch (action)
                    {
                        case 1:
                            Console.WriteLine("----------------------\nAdd a Book\n");
                            Book book = GetBooksData();
                            bookActions.AddBook(book);
                            Console.WriteLine("\nBook is added.\n");
                            break;
                        case 2:
                            Console.WriteLine("----------------------\nTake a Book\n");
                            Console.WriteLine("Action unavailable.");
                            break;
                        case 3:
                            Console.WriteLine("----------------------\nReturn a Book\n");
                            Console.WriteLine("Action unavailable.");
                            break;
                        case 4:
                            Console.WriteLine("----------------------\nView Books\n");
                            Console.WriteLine("Filter the list? y/n");
                            string anw = Console.ReadLine();
                            if (anw.StartsWith('y'))
                            {
                                Console.WriteLine("\nAvailable filters:");
                                int i = 0;
                                foreach(Filters filter in Enum.GetValues(typeof(Filters)))
                                {
                                    Console.WriteLine(i++ + ". " + filter);
                                }
                                Console.WriteLine("\nEnter preferred filter's number:");
                                int filterType = Int32.Parse(Console.ReadLine());
                                
                                List<Book> filteredList = GetFilteredList(filterType);
                                if(filteredList.Count > 0)
                                {
                                    PrintFilteredBookList(filteredList);
                                }
                                else
                                {
                                    Console.WriteLine("No books found.");
                                }

                            } else if (anw.StartsWith('n'))
                            {
                                PrintAllBookList(bookActions);
                            } else
                            {
                                Console.WriteLine("Illegal answer.");
                            }

                            break;
                        case 5:
                            Console.WriteLine("----------------------\nDelete a Book\n");
                            PrintSimplifiedBookList(bookActions);
                            int nr = AskForBookNr();
                            DeleteBook(bookActions, nr);
                            Console.WriteLine("\nBook is deleted.\n");
                            break;
                        default:
                            Console.WriteLine("Enter available action.");
                            break;
                
                    }
                    Console.WriteLine(actionString);
                    action = Int32.Parse(Console.ReadLine());

                    if(Validation.CheckInt(action))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Please enter an available action's number.");
                    }

                }
            } else
            {
                Console.WriteLine("Please enter an available action's number.");
            }

            Console.WriteLine("Exiting Library");
        }

        private static List<Book> GetFilteredList(int filterType)
        {
            FilterActions filterActions = new();
            switch (filterType)
            {
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

                /*case (int)Filters.Availability:
                    Console.WriteLine("Enter availability: taken/available");
                    string availability = Console.ReadLine();
                    return filterActions.FilterByName(availability);*/
                default:
                    Console.WriteLine("Filter not found.");
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
        private static void PrintAllBookList(BookActions bookActions)
        {
            List<Book> books = bookActions.GetBookList();
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

        private static void PrintSimplifiedBookList(BookActions bookActions)
        {
            List<Book> books = bookActions.GetBookList();

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(i + ". " + books[i].Name);
            }
        }

        private static int AskForBookNr()
        {
            Console.WriteLine("Enter book number to delete:");
            return Int32.Parse(Console.ReadLine());
        }

        private static void DeleteBook(BookActions bookActions, int nr)
        {
            bookActions.DeleteBook(nr);
        }
        
    }
}
