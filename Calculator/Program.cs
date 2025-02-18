using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var y = false;
            do
            {
                Console.WriteLine("Enter the first number");
                var fNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the operator");
                var op = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter the second number.");
                var sNum = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case '+':
                        Console.WriteLine($"Sum: {fNum + sNum}");
                        break;
                    case '-':
                        Console.WriteLine($"Sum: {fNum - sNum}");
                        break;
                    case '*':
                        Console.WriteLine($"Sum: {fNum * sNum}");
                        break;
                    case '/':
                        Console.WriteLine($"Sum: {fNum / sNum}");
                        break;
                    default:
                        Console.WriteLine("we don't have operation like this");
                        break;
                }
                Exit();

            } while (y);

            return;

            void Exit()
            {
                Console.WriteLine("Spacebar__continue");
                Console.WriteLine("Tab__Exit");
                var qwerty = true;
                do
                {
                    var next = Console.ReadKey();
                    switch (next.Key)
                    {
                        case ConsoleKey.Spacebar:
                            y = true;
                            qwerty = false;
                            break;
                        case ConsoleKey.Tab:
                            qwerty = false;
                            y = false;
                            break;
                        default:
                            Console.WriteLine();
                            break;
                    }

                    Console.WriteLine("try again!");

                } while (qwerty);

            }
        }
    }
}
