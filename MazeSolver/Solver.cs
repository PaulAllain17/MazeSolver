using System;
using System.Collections.Generic;

namespace MazeSolver
{
    public class Solver
    {
        private Maze _maze;

        public Solver(Maze maze)
        {
            _maze = maze;
        }

        public void Solve()
        {
            if (!StartIsValid())
                return;

            Move(_maze.Start, _maze.End, _maze.Width, _maze.Height, _maze.Structure);
        }

        private bool StartIsValid()
        {
            if (_maze.Start.x >= _maze.Width || _maze.Start.y >= _maze.Height)
                return false;

            if (_maze.Structure[_maze.Start.x][_maze.Start.y] == 1)
                return false;

            return true;
        }

        private void Move(Coordinate currentPosition, Coordinate end, int width, int height, List<List<int>> structure)
        {
            throw new NotImplementedException();
        }
    }
}