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
                SolveMaze();
            }
        }

        private static void SolveMaze()
        {
            Console.WriteLine("Type file path of your maze:");
            var filePath = Console.ReadLine();

            var lines = Reader.ReadFile(filePath);
            if (lines.Count == 0)
            {
                Layout.Write("Could not read your file, make sure the path is correct.");
                return;
            }

            var maze = Formatter.CreateMaze(lines);
            var solver = new Solver(maze);
            var result = solver.Solve();

            if (!result.Equals(maze.End))
            {
                Layout.Write("Your maze could not be solved!");
                return;
            }

            Console.WriteLine();
            Layout.Display(maze);
            Layout.Write("Your maze has been solved!");
        }
    }
}
