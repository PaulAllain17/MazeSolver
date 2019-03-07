using System;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 200;

            var reader = new Reader();
            var maze = reader.ReadFile();
            var solver = new Solver(maze);
            solver.Solve();
            reader.Display(maze);

            Console.WriteLine();
            Console.WriteLine("Type key to exit.");
            Console.ReadKey();
        }
    }
}
