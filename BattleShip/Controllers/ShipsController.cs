using BattleShip.ModelHelpers;
using BattleShip.ModelHelpers.Structures;
using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip.Controllers
{
    class ShipsController
    {
        private List<Ship> _ships;

        private readonly List<Point> _usedCells = new List<Point>();

        private readonly int[] _goodCells = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        private int _createdShips;

        private int _ruleNumber;

        private int[] _shipCreationRule;

        readonly List<Point> _availableCoordinates = GetCoordintes();

        public List<Ship> CreateShips()
        {
            _ships = new List<Ship>();
            _createdShips = 0;
            _ruleNumber = 0;
            _shipCreationRule = new[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
            while (_createdShips < 10)
            {
                Orientation orientation = GetOrientation();
                int size = GetShipSize();
                _ships.Add(new Ship(GetCoordinates(orientation, size), size, orientation));
                _ruleNumber++;
                _createdShips++;
            }
            return _ships;
        }

        private static List<Point> GetCoordintes()
        {
            List<Point> points = new List<Point>();
            for (int x = 1; x < 11; x++)
            {
                for (int y = 1; y < 11; y++)
                {
                    points.Add(new Point 
                    { 
                        X = x, 
                        Y = y 
                    });
                }
            }
            return points;
        }

        private Orientation GetOrientation()
        {
            var randomValue = new Random().Next(1, 3);
            return (Orientation)randomValue;
        }

        private int GetShipSize() => _shipCreationRule[_ruleNumber];

        private Point GetCoordinates(Orientation orientation, int size)
        {
            Point shipCoordinates;

            do
            {
                var randomValue = new Random().Next(0, _availableCoordinates.Count);
                shipCoordinates = new Point
                {
                    X = _availableCoordinates.ElementAt(randomValue).X,
                    Y = _availableCoordinates.ElementAt(randomValue).Y
                };

            }
            while (!IsCoordinatesAvailable(shipCoordinates, orientation, size));

            FillUsedCoordinates(shipCoordinates, size, orientation);
            RemovUnusedCoordinates(_availableCoordinates, _usedCells);
            return shipCoordinates;
        }

        private void RemovUnusedCoordinates(List<Point> unusedCoordinates, List<Point> usedCoorindates)
        {
            foreach (Point usedCoorindate in usedCoorindates)
            {
                unusedCoordinates.Remove(usedCoorindate);
            }
        }

        private bool IsCoordinatesAvailable(Point coordinate, Orientation orientation, int size)
        {
            if (orientation == Orientation.Horizontal)
            {
                var tempPoint = new Point
                {
                    X = coordinate.X + size,
                    Y = coordinate.Y
                };
                if (!ChekOutOfRange(tempPoint) && !_usedCells.Contains(tempPoint))
                {
                    return true;
                }
            }
            else
            {
                var tempPoint = new Point
                {
                    X = coordinate.X,
                    Y = coordinate.Y + size
                };
                if (!ChekOutOfRange(tempPoint) && !_usedCells.Contains(tempPoint))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ChekOutOfRange(Point coordinate)
        {

            if (_goodCells.Contains(coordinate.X) && _goodCells.Contains(coordinate.Y))
            {
                return false;
            }
            return true;
        }

        private void FillUsedCoordinates(Point usedCell, int size, Orientation orientation)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < size + 1; j++)
                {
                    if (orientation == Orientation.Horizontal)
                    {
                        _usedCells.Add(new Point
                        {
                            X = usedCell.X + j,
                            Y = usedCell.Y + i
                        });
                    }
                    else
                    {
                        _usedCells.Add(new Point
                        {
                            X = usedCell.X + i,
                            Y = usedCell.Y + j
                        });
                    }
                }
            }
        }
    }
}

