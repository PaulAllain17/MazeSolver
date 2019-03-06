using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeSolver
{
    public class Solver
    {
        private Maze _maze;

        public Solver(Maze maze)
        {
            _maze = maze;
        }

        public List<Coordinate> Solve()
        {
            if (!StartIsValid())
                return new List<Coordinate>();

            var path = new List<Coordinate>();

            var finished = MoveUp(_maze.Start, _maze.End, _maze.Width, _maze.Height, _maze.Structure, path);
            if (finished)
            {
                return path;
            }

            finished = MoveDown(_maze.Start, _maze.End, _maze.Width, _maze.Height, _maze.Structure, path);
            if (finished)
            {
                return path;
            }

            finished = MoveRight(_maze.Start, _maze.End, _maze.Width, _maze.Height, _maze.Structure, path);
            if (finished)
            {
                return path;
            }

            var pathLeft = MoveLeft(_maze.Start, _maze.End, _maze.Width, _maze.Height, _maze.Structure, path);
            if (finished)
            {
                return path;
            }

            return new List<Coordinate>();
        }

        private bool StartIsValid()
        {
            if (_maze.Start.x >= _maze.Width || _maze.Start.y >= _maze.Height)
                return false;

            if (_maze.Structure[_maze.Start.y][_maze.Start.x] == 1)
                return false;

            return true;
        }

        private bool MoveUp(Coordinate currentPosition, Coordinate end, int width, int height,
            List<List<int>> structure, List<Coordinate> path)
        {
            Coordinate newPosition;
            if (currentPosition.y + 1 >= height)
            {
                newPosition = new Coordinate(currentPosition.x, 0);
            }
            else
            {
                newPosition = new Coordinate(currentPosition.x, currentPosition.y + 1);
            }

            return NextMove(end, width, height, structure, path, newPosition);
        }

        private bool MoveDown(Coordinate currentPosition, Coordinate end, int width, int height,
            List<List<int>> structure, List<Coordinate> path)
        {
            Coordinate newPosition;
            if (currentPosition.y - 1 < 0)
            {
                newPosition = new Coordinate(currentPosition.x, height);
            }
            else
            {
                newPosition = new Coordinate(currentPosition.x, currentPosition.y - 1);
            }

            return NextMove(end, width, height, structure, path, newPosition);
        }

        private bool MoveRight(Coordinate currentPosition, Coordinate end, int width, int height,
            List<List<int>> structure, List<Coordinate> path)
        {
            Coordinate newPosition;
            if (currentPosition.x + 1 >= width)
            {
                newPosition = new Coordinate(0, currentPosition.y);
            }
            else
            {
                newPosition = new Coordinate(currentPosition.x + 1, currentPosition.y);
            }

            return NextMove(end, width, height, structure, path, newPosition);
        }

        private bool MoveLeft(Coordinate currentPosition, Coordinate end, int width, int height,
            List<List<int>> structure, List<Coordinate> path)
        {
            Coordinate newPosition;
            if (currentPosition.x - 1 < 0)
            {
                newPosition = new Coordinate(width, currentPosition.y);
            }
            else
            {
                newPosition = new Coordinate(currentPosition.x - 1, currentPosition.y);
            }

            return NextMove(end, width, height, structure, path, newPosition);
        }

        private bool NextMove(Coordinate end, int width, int height, List<List<int>> structure, List<Coordinate> path, Coordinate newPosition)
        {
            if (!IsValidPosition(structure, path, newPosition)) return false;

            path.Add(newPosition);

            if (newPosition.Equals(end))
                return true;

            var finished = MoveUp(newPosition, end, width, height, structure, path);
            if (finished)
                return true;

            path.Remove(newPosition);

            finished = MoveDown(newPosition, end, width, height, structure, path);
            if (finished)
                return true;

            finished = MoveRight(newPosition, end, width, height, structure, path);
            if (finished)
                return true;

            finished = MoveLeft(newPosition, end, width, height, structure, path);
            if (finished)
                return true;

            return false;
        }

        private bool IsValidPosition(List<List<int>> structure, List<Coordinate> path, Coordinate newPosition)
        {
            if (newPosition.Equals(_maze.Start))
                return false;

            if (newPosition.IsWall(structure))
                return false;

            var origin = path.LastOrDefault();
            if (newPosition.Equals(origin))
                return false;
            return true;
        }
    }
}