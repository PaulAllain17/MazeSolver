using System;
using System.IO;
using System.Linq;

namespace MazeSolver
{
    public class Reader : IDisposable
    {
        public Maze ReadFile()
        {
            var lines = File.ReadLines("../.././Samples/input.txt").ToList();
            var size = lines[0].Split(' ');
            var width = int.Parse(size[0]);
            var height = int.Parse(size[1]);
            var start = lines[1].Split(' ');
            var startCoord = new Coordinate(int.Parse(start[0]), int.Parse(start[1]));
            var end = lines[2].Split(' ');
            var endCoord = new Coordinate(int.Parse(end[0]), int.Parse(end[1]));
            return new Maze(height, width, startCoord, endCoord);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
