using System;
using System.Collections.Generic;

namespace MazeSolver
{
    public struct Coordinate
    {
        public int x, y;

        public Coordinate(int x1, int y1)
        {
            x = x1;
            y = y1;
        }

        public bool IsWall(List<List<int>> structure)
        {
            if (structure[y][x] == 1)
                return true;

            return false;
        }

        public bool Equals(Coordinate coord)
        {
            if (coord.x == x && coord.y == y)
                return true;

            return false;
        }
    }
}