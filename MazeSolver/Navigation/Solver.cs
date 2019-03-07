namespace MazeSolver
{
    public class Solver
    {
        private Maze _maze;

        public Solver(Maze maze)
        {
            _maze = maze;
        }

        public Coordinate Solve()
        {
            MarkAsVisited(_maze.Start);
            return RecursiveMaze(_maze.Start);
        }

        private Coordinate RecursiveMaze(Coordinate currentLocation)
        {
            if (currentLocation.Equals(_maze.End))
                return currentLocation;

            var newPosition = currentLocation.Up(_maze.Height);
            if (Move(newPosition, out var location)) return location;

            newPosition = currentLocation.Down(_maze.Height);
            if (Move(newPosition, out location)) return location;

            newPosition = currentLocation.Right(_maze.Width);
            if (Move(newPosition, out location)) return location;

            newPosition = currentLocation.Left(_maze.Width);
            if (Move(newPosition, out location)) return location;

            return currentLocation;
        }

        private bool Move(Coordinate newPosition, out Coordinate location)
        {
            location = new Coordinate();

            if (IsValid(newPosition))
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