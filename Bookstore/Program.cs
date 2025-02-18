using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Bookstore
{
    public class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            BookManager bookManager = new BookManager();

            bookManager.books.Add(new Book
            {
                Author = "Harper Lee",
                Title = "To Kill a Mockingbird",
                Year = 1960
            });
            bookManager.books.Add(new Book
            {
                Author = "J.K. Rowling",
                Title = "Harry Potter and the Philosopher's Stone",
                Year = 1997
            });
            bookManager.books.Add(new Book
            {
                Author = "F. Scott Fitzgerald",
                Title = "The Great Gatsby",
                Year = 1925
            });

            var path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Books.txt";
            List<Book> data = null;

            Serialization(JsonConvert.SerializeObject(bookManager.books));
            Deserialization();

            var exit = true;

            do
            {
                Choice();
                Exit();

            } while (exit);

            DeleteFile();

            void Exit()
            {
                bool wrong = true;
                Console.WriteLine("press spaceBar bar to continue");
                Console.WriteLine("press tab to Exit");

                var wuw = Console.ReadKey();//what user wants
                do
                {
                    switch (wuw.Key)
                    {
                        case ConsoleKey.Spacebar:
                            Console.WriteLine();
                            wrong = false;
                            break;
                        case ConsoleKey.Tab:
                            exit = true;
                            break;
                        default:
                            throw new Exception("wrong button");
                    }
                } while (wrong);
            }

            void AddBook()
            {
                Console.Write("enter title: ");
                string title = Console.ReadLine();
                Console.Write("enter author: ");
                string author = Console.ReadLine();
                Console.Write("enter year: ");
                int year = int.Parse(Console.ReadLine());
                Book book1 = new Book()
                {
                    Title = title,
                    Author = author,
                    Year = year
                };
                bookManager.AddBook(data, book1);
            }

            void Choice()
            {
                Console.WriteLine("F1. View all books");
                Console.WriteLine("F2. Add a book");
                Console.WriteLine("F3. Search the book by name");
                bool mistake = true;
                do
                {
                    var key = Console.ReadKey();

                    switch (key.Key)
                    {
                        case ConsoleKey.F1:
                            bookManager.ShowAllBook(data);
                            mistake = false;
                            break;
                        case ConsoleKey.F2:
                            AddBook();
                            mistake = false;
                            break;
                        case ConsoleKey.F3:
                        {
                            Console.WriteLine("enter the book Title");
                            var title = Console.ReadLine();
                            bookManager.SearchbookByItsTitle(title, data);
                            mistake = false;
                            break;
                        }
                        default:
                            mistake = true;
                            break;
                    }
                } while (mistake);
            }

            void DeleteFile()
            {
                if (File.Exists(path))
                    File.Delete(path);
            }

            void Deserialization()
            {
                data = JsonConvert.DeserializeObject<List<Book>>(FileManager.ReadFile(path));
            }

            void Serialization(string content)
            {
                FileManager.WriteFile(path, content);
            }
        }
    }
}
