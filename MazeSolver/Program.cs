using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var maze = reader.ReadFile();
            var solver = new Solver(maze);
            Console.WriteLine($"Start: {maze.Start.x} {maze.Start.y}");
            Console.WriteLine($"End: {maze.End.x} {maze.End.y}");
            reader.DisplayMaze(new List<Coordinate>(), maze);
            var path = solver.Solve();
            Console.WriteLine();
            reader.Display(path, maze);
            Console.WriteLine("Type key to exit.");
            Console.ReadKey();
        }
    }
}
