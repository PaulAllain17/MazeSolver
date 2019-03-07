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
            MarkAsVisited(_maze.Start);
            var location = RecursiveMaze(_maze.Start);
        }

        private Coordinate RecursiveMaze(Coordinate currentLocation)
        {
            if (currentLocation.Equals(_maze.End))
                return currentLocation;

            var newPosition = currentLocation.Up();
            if (IsValid(newPosition))
            {
                if (Move(newPosition, out var location)) return location;
            }

            newPosition = currentLocation.Down();
            if (IsValid(newPosition))
            {
                if (Move(newPosition, out var location)) return location;
            }

            newPosition = currentLocation.Right();
            if (IsValid(newPosition))
            {
                if (Move(newPosition, out var location)) return location;
            }

            newPosition = currentLocation.Left();
            if (IsValid(newPosition))
            {
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

        private bool IsValid(Coordinate currentLocation)
        {
            return IsNotWall(currentLocation) && IsUnVisited(currentLocation);
        }

        private bool IsUnVisited(Coordinate currentLocation)
        {
            if (_maze.Structure[currentLocation.y][currentLocation.x] == 0)
                return true;

            return false;
        }

        private bool IsNotWall(Coordinate currentLocation)
        {
            if (_maze.Structure[currentLocation.y][currentLocation.x] == 1)
                return false;

            return true;
        }
    }
}