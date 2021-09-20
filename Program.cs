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
                                        "\nEnter preferred action number: ";

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
                            GetBooksData(bookActions);
                            Console.WriteLine("\nBook is added.\n");
                            break;
                        case 2:
                            Console.WriteLine("----------------------\nTake a Book\n");
                            break;
                        case 3:
                            Console.WriteLine("----------------------\nReturn a Book\n");
                            break;
                        case 4:
                            Console.WriteLine("----------------------\nView Books\n");
                            PrintBookList(bookActions);
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

        private static void PrintBookList(BookActions bookActions)
        {
            List<Book> books = bookActions.GetBookList(Filters.None);
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
        private static void GetBooksData(BookActions bookActions)
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

            bookActions.AddBook(book);
        }

        private static void PrintSimplifiedBookList(BookActions bookActions)
        {
            List<Book> books = bookActions.GetBookList(Filters.None);

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
