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
            Console.WriteLine($"Start: {maze.Start.x} {maze.Start.y}");
            Console.WriteLine($"End: {maze.End.x} {maze.End.y}");

            var solver = new Solver(maze);
            var path = solver.Solve();
            Console.WriteLine();
            reader.Display(maze);
            Console.WriteLine("Type key to exit.");
            Console.ReadKey();
        }
    }
}
