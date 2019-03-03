using System;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var maze = reader.ReadFile();
            var solver = new Solver(maze);
            solver.Solve();
            Console.WriteLine("Type key to exit.");
            Console.ReadKey();
        }
    }
}
