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

        public Coordinate Up(int mazeHeight)
        {
            var newY = y + 1;
            if (newY >= mazeHeight)
                newY = 0;
            return new Coordinate(x, newY);
        }

        public Coordinate Down(int mazeHeight)
        {
            var newY = y - 1;
            if (newY < 0)
                newY = mazeHeight - 1;
            return new Coordinate(x, newY);
        }

        public Coordinate Right(int mazeWidth)
        {
            var newX = x + 1;
            if (newX >= mazeWidth)
                newX = 0;
            return new Coordinate(newX, y);
        }

        public Coordinate Left(int mazeWidth)
        {
            var newX = x - 1;
            if (newX < 0)
                newX = mazeWidth - 1;
            return new Coordinate(newX, y);
        }
    }
}