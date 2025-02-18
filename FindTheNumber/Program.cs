using System;

namespace FindTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var toFind = rnd.Next(20);
            var attempt = 0;
            var y = true;

            Console.WriteLine("Find the number (1-20)");
            do
            {
                var userChoice = int.Parse(Console.ReadLine());

                if(userChoice > toFind)
                {
                    attempt++;
                    Console.WriteLine($"lower. attempt: {attempt}");
                }else if(userChoice < toFind)
                {
                    attempt++;
                    Console.WriteLine($"higher. attempt: {attempt}");
                }
                else if (userChoice == toFind)
                {
                    Console.WriteLine("you won");
                    Console.WriteLine($"attempts: {attempt}");
                    y = false;
                    Exit();
                }

                if (attempt != 5) continue;
                y = false;
                Console.WriteLine("you lost");

            } while (y);

            return;

            void Exit()
            {
                Console.WriteLine("Spacebar__continue");
                Console.WriteLine("Tab__Exit");
                var asd = true;
                do
                {
                    var next = Console.ReadKey();
                    switch (next.Key)
                    {
                        case ConsoleKey.Spacebar:
                            y = true;
                            asd = false;
                            break;
                        case ConsoleKey.Tab:
                            asd = false;
                            y = false;
                            break;
                        default:
                            Console.WriteLine("no such operands");
                            break;
                    }
                    Console.WriteLine("try again");

                } while (asd);

            }
        }
    }
}
