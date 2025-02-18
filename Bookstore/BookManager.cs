using System;
using System.Collections.Generic;

namespace Bookstore
{
     public class BookManager
    {
        public List<Book> books = new List<Book>(); 

        public void AddBook(List<Book> books, Book book)
        {
            books.Add(book);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Added Successfully");
            Console.ResetColor();

        }
        public void ShowAllBook(List<Book> books)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in books)
            {
                Console.WriteLine($"{books.IndexOf(item) + 1}. {item.ToString()}");
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public void SearchbookByItsTitle(string title, List<Book> books)
        {
            var search = false;

            foreach (var item in books)
            {

                if (item.Title == title)
                {
                    Console.WriteLine(item.ToString());
                    search = true;
                    break;
                }
                else
                    search = false;
               
            }
            if (!search)
                throw new Exception("No book found with this name");
        }
    }
}
