using System;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var test = reader.ReadFile();
            Console.WriteLine("Type key to exit.");
            Console.ReadKey();
        }
    }
}
