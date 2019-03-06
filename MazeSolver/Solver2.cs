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
                return currentLocation;

            if (UpIsValid(currentLocation))
            {
                var newPosition = currentLocation.Up();
                if (Move(newPosition, out var location)) return location;
            }

            if (DownIsValid(currentLocation))
            {
                var newPosition = currentLocation.Down();
                if (Move(newPosition, out var location)) return location;
            }

            if (RightIsValid(currentLocation))
            {
                var newPosition = currentLocation.Right();
                if (Move(newPosition, out var location)) return location;
            }

            if (LeftIsValid(currentLocation))
            {
                var newPosition = currentLocation.Left();
                if (Move(newPosition, out var location)) return location;
            }

            return currentLocation;
        }

        private bool Move(Coordinate newPosition, out Coordinate location)
        {
            MarkAsVisited(newPosition);
            location = RecursiveMaze(newPosition);

            if (location.Equals(_maze.End))
            {
                return true;
            }

            RemoveMark(newPosition);
            return false;
        }

        private void RemoveMark(Coordinate newPosition)
        {
            _maze.Structure[newPosition.y][newPosition.x] = 0;
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