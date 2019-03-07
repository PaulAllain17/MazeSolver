using System.Collections.Generic;

namespace MazeSolver
{
    public class Maze
    {
        public Maze(int height, int width, Coordinate start, Coordinate end)
        {
            Height = height;
            Width = width;
            Start = start;
            End = end;
            Structure = new List<List<int>>();
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public Coordinate Start { get; set; }
        public Coordinate End { get; set; }
        public List<List<int>> Structure { get; set; }
    }
}