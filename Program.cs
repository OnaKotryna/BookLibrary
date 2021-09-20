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
            Console.WriteLine("Available actions:   \n1 - add a book" +
                                                    "\n2 - take a book" +
                                                    "\n3 - return a book" +
                                                    "\n4 - view all books" +
                                                    "\n5 - delete a book" +
                                                    "\n0 - exit");
            Console.WriteLine("Enter prefferd action: ");
            int action = Int32.Parse(Console.ReadLine());
            if (Validation.CheckInt(action))
            {
                BookActions bookActions = new();
                string datePattern = "yyyy-MM-dd";
                while (action != 0)
                { 
                    switch (action)
                    {
                        case 1:
                            Console.WriteLine("Add a Book");

                            Book book = new Book();

                            Console.WriteLine("Name: ");
                            book.Name = Console.ReadLine();
                            Console.WriteLine("Author: ");
                            book.Author = Console.ReadLine();
                            Console.WriteLine("Category: ");
                            book.Category = Console.ReadLine();
                            Console.WriteLine("Language: ");
                            book.Language = Console.ReadLine();
                            Console.WriteLine("Publication date: \n(format: " + datePattern);
                            book.Published = DateTime.ParseExact(Console.ReadLine(), datePattern, null);
                            Console.WriteLine("ISBN: ");
                            book.Isbn = Console.ReadLine();

                            bookActions.AddBook(book);
                            Console.WriteLine("Book is added.\n");
                            
                            break;
                        case 2:
                            Console.WriteLine("Take a Book");
                            break;
                        case 3:
                            Console.WriteLine("Return a Book");
                            break;
                        case 4:
                            Console.WriteLine("View Books");
                            List<Book> books = bookActions.GetBookList(Filters.None);
                            foreach (var bk in books)
                            {
                                Console.WriteLine("Name: {0}" +
                                    "\nAuthor: {1}" +
                                    "\nCategory {2}" +
                                    "\nLanguage {3}" +
                                    "\nPublication date: {4}" +
                                    "\nISBN: {5}\n", bk.Name, bk.Author, bk.Category, bk.Language, bk.Published.ToString(datePattern), bk.Isbn);
                            }
                            break;
                        case 5:
                            Console.WriteLine("Delete a Book");
                            break;
                        default:
                            Console.WriteLine("Enter available action.");
                            break;
                
                    }
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
    }
}
