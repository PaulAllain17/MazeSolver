using System;
using System.Collections.Generic;

namespace MazeSolver
{
    public class Solver2
    {
        private Maze _maze;

        public Solver2(Maze maze)
        {
            _maze = maze;
        }

        public List<Coordinate> Solve()
        {
            var location = RecursiveMaze(_maze.Start);

            return new List<Coordinate>();
        }

        private Coordinate RecursiveMaze(Coordinate currentLocation)
        {
            if (currentLocation.Equals(_maze.End))
            {
                return currentLocation;
            }

            if (UpIsValid(currentLocation))
            {
                currentLocation.Up();
                MarkAsVisited(currentLocation);
                var location = RecursiveMaze(currentLocation);
                if (location.Equals(_maze.End))
                    return location;
            }

            if (DownIsValid(currentLocation))
            {
                currentLocation.Down();
                MarkAsVisited(currentLocation);
                var location = RecursiveMaze(currentLocation);
                if (location.Equals(_maze.End))
                    return location;
            }

            if (RightIsValid(currentLocation))
            {
                currentLocation.Right();
                MarkAsVisited(currentLocation);
                var location = RecursiveMaze(currentLocation);
                if (location.Equals(_maze.End))
                    return location;
            }

            if (LeftIsValid(currentLocation))
            {
                currentLocation.Left();
                MarkAsVisited(currentLocation);
                var location = RecursiveMaze(currentLocation);
                if (location.Equals(_maze.End))
                    return location;
            }

            return currentLocation;
        }

        private void MarkAsVisited(Coordinate currentLocation)
        {
            _maze.Structure[currentLocation.y][currentLocation.x] = -1;
        }

        private bool UpIsValid(Coordinate currentLocation)
        {
            return UpIsNotWall(currentLocation) && UpIsUnVisited(currentLocation);
        }

        private bool UpIsUnVisited(Coordinate currentLocation)
        {
            if (_maze.Structure[currentLocation.y + 1][currentLocation.x] == 0)
                return true;

            return false;
        }

        private bool UpIsNotWall(Coordinate currentLocation)
        {
            if (_maze.Structure[currentLocation.y + 1][currentLocation.x] == 1)
                return false;

            return true;
        }

        private bool DownIsValid(Coordinate currentLocation)
        {
            return DownIsNotWall(currentLocation) && DownIsUnVisited(currentLocation);
        }

        private bool DownIsUnVisited(Coordinate currentLocation)
        {
            if (_maze.Structure[currentLocation.y - 1][currentLocation.x] == 0)
                return true;

            return false;
        }

        private bool DownIsNotWall(Coordinate currentLocation)
        {
            if (_maze.Structure[currentLocation.y - 1][currentLocation.x] == 1)
                return false;

            return true;
        }

        private bool RightIsValid(Coordinate currentLocation)
        {
            return RightIsNotWall(currentLocation) && RightIsUnVisited(currentLocation);
        }

        private bool RightIsUnVisited(Coordinate currentLocation)
        {
            if (_maze.Structure[currentLocation.y][currentLocation.x + 1] == 0)
                return true;

            return false;
        }

        private bool RightIsNotWall(Coordinate currentLocation)
        {
            if (_maze.Structure[currentLocation.y][currentLocation.x + 1] == 1)
                return false;

            return true;
        }

        private bool LeftIsValid(Coordinate currentLocation)
        {
            return LeftIsNotWall(currentLocation) && LeftIsUnVisited(currentLocation);
        }

        private bool LeftIsUnVisited(Coordinate currentLocation)
        {
            if (_maze.Structure[currentLocation.y][currentLocation.x - 1] == 0)
                return true;

            return false;
        }

        private bool LeftIsNotWall(Coordinate currentLocation)
        {
            if (_maze.Structure[currentLocation.y][currentLocation.x - 1] == 1)
                return false;

            return true;
        }
    }
}