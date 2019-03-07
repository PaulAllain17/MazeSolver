using System;

namespace MazeSolver
{
    public class Layout
    {
        public static void Display(Maze maze)
        {
            maze.Structure[maze.Start.y][maze.Start.x] = 2;
            maze.Structure[maze.End.y][maze.End.x] = 3;

            for (var y = 0; y < maze.Height; y++)
            {
                for (var x = 0; x < maze.Width; x++)
                {
                    switch (maze.Structure[y][x])
                    {
                        case 0:
                            Console.Write(" ");
                            break;
                        case 1:
                            Console.Write("#");
                            break;
                        case 2:
                            Console.Write("S");
                            break;
                        case 3:
                            Console.Write("E");
                            break;
                        case -1:
                            Console.Write("X");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public static void Write(string text)
        {
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();
        }
    }
}