using System;

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
            while (action != 0)
            {
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Add a Book");
                        break;
                    case 2:
                        Console.WriteLine("Take a Book");
                        break;
                    case 3:
                        Console.WriteLine("Return a Book");
                        break;
                    case 4:
                        Console.WriteLine("View Books");
                        break;
                    case 5:
                        Console.WriteLine("Delete a Book");
                        break;
                    default:
                        Console.WriteLine("Enter available action.");
                        break;

                }
                action = Int32.Parse(Console.ReadLine());
            }

            Console.WriteLine("Exiting Library");
        }
    }
}
