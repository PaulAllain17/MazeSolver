using System.Collections.Generic;

namespace MazeSolver
{
    public class Formatter
    {
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