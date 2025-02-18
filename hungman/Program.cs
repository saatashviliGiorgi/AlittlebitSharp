using hungman;
using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using Newtonsoft.Json;

namespace Hangman
{

    public class Program
    {
        private static void Main(string[] args)
        {
            var words = new string[]//gaitane failshi
            {
                "apple", "banana", "cherry", "date", "elderberry",
                "fig", "grape", "honeydew", "kiwi", "lemon"
            };



            var path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/words.txt";

            var json = JsonConvert.SerializeObject(words);

            FileManager.WriteFile(path, json);

            var deserialization = FileManager.ReadFile(path);

            var data = JsonConvert.DeserializeObject<string[]>(deserialization);

            var rnd = new Random();
            var randomIndex = rnd.Next(data.Count());
            var next = true;
            var HangWord = data[randomIndex];
            var Splitted = HangWord.ToCharArray();
            var usedChars = new List<char>();
            var newWord = new List<char>();
            for (var i = 0; i < Splitted.Length; i++)
            {
                newWord.Add('_');
            }

            foreach (var item in newWord)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("You have to guess the word...");
            var attempts = 10;

            do
            {
                Console.Write("Enter a letter: ");
                var letter = Console.ReadLine();
                if (usedChars.Contains(Convert.ToChar(letter)))
                {
                    Console.WriteLine("You Already Used This Key");
                    Attempt();
                }

                else if (Splitted.Contains(Convert.ToChar(letter)) || usedChars.Contains(Convert.ToChar(letter)))
                {
                    usedChars.Add(Convert.ToChar(letter));
                }

                if (!Splitted.Contains(Convert.ToChar(letter)))
                {
                    Console.WriteLine("that letter isn't in the word");
                    Attempt();
                }

                for (var i = 0; i < Splitted.Length; i++)
                {
                    if (letter != Splitted[i].ToString()) continue;
                    for (var j = 0; j < newWord.Count; j++)
                    {
                        newWord[i] = Convert.ToChar(letter);
                    }
                }

                foreach (var item in newWord)
                {
                    Console.Write(item);
                }

                Console.WriteLine();

                if (!newWord.Contains('_'))
                {
                    next = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("you Won!");
                    Console.Write($"attempts left: {attempts}");
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                if (attempts > 0) continue;
                next = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("you Lost");
                Console.ResetColor();
            } while (next);

            if (!File.Exists(path)) return;
            File.Delete(path);
            Console.WriteLine("file has been deleted");
            return;

            void Attempt()
            {
                attempts--;
                Console.WriteLine($"attempts: {attempts}");
            }
        }
    }
}