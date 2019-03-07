﻿using System;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 200;

            while (true)
            {
                Console.WriteLine("Type file path of your maze:");
                var filePath = Console.ReadLine();
                Console.WriteLine();

                var lines = Reader.ReadFile(filePath);
                if (lines.Count == 0)
                {
                    Console.WriteLine("Could not read your file, make sure the path is correct.");
                    Console.WriteLine();
                    continue;
                }

                var maze = Reader.CreateMaze(lines);
                var solver = new Solver(maze);
                solver.Solve();
                Reader.Display(maze);

                Console.WriteLine();
                Console.WriteLine("Your maze has been solved!");
                Console.WriteLine();
            }
        }
    }
}
