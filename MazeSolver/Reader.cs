using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MazeSolver
{
    public class Reader
    {
        public static List<string> ReadFile(string path)
        {
            List<string> lines;
            try
            {
                lines = File.ReadLines(path).ToList();
            }
            catch
            {
                return new List<string>();
            }

            return lines;
        }

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

        public static Maze CreateMaze(List<string> lines)
        {
            var size = lines[0].Split(' ');
            var width = int.Parse(size[0]);
            var height = int.Parse(size[1]);

            var start = lines[1].Split(' ');
            var startCoord = new Coordinate(int.Parse(start[0]), int.Parse(start[1]));
            var end = lines[2].Split(' ');
            var endCoord = new Coordinate(int.Parse(end[0]), int.Parse(end[1]));

            var maze = new Maze(height, width, startCoord, endCoord);

            PopulateMazeStructure(lines, width, maze);

            return maze;
        }

        private static void PopulateMazeStructure(List<string> lines, int width, Maze maze)
        {
            var lineCount = lines.Count;
            for (var i = 3; i < lineCount; i++)
            {
                var line = lines[i].Split(' ');
                var row = new List<int>();
                for (int columnIndex = 0; columnIndex < width; columnIndex++)
                {
                    row.Add(int.Parse(line[columnIndex]));
                }

                maze.Structure.Add(row);
            }
        }
    }
}
