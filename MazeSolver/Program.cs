using System;

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

                var lines = Reader.ReadFile(filePath);
                if (lines.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Could not read your file, make sure the path is correct.");
                    Console.WriteLine();
                    continue;
                }

                var maze = Formatter.CreateMaze(lines);
                var solver = new Solver(maze);
                var result = solver.Solve();

                if (!result.Equals(maze.End))
                {
                    Console.WriteLine();
                    Console.WriteLine("Your maze could not be solved!");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine();
                Layout.Display(maze);

                Console.WriteLine();
                Console.WriteLine("Your maze has been solved!");
                Console.WriteLine();
            }
        }
    }
}
