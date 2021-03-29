using BattleShip.Structures;
using System;
using System.Collections.Generic;

namespace BattleShip.Controllers
{
    class ShipsController
    {
        private int createdShip;

        private int ruleNumber;

        private int[] shipCreationRule;

        private List<Point> usesCells;

        private List<Ship> ships;

        public List<Ship> CreateShips()
        {
            createdShip = 0;
            ruleNumber = 0;
            shipCreationRule = new[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
            usesCells = new List<Point>();
            ships = new List<Ship>();
            Ship ship;
            while (createdShip < 10)
            {
                do
                {
                    ship = new Ship(GetRandomPoint(), GetShipSize(), GetRandomOrientation());
                }
                while (CheckShipPosition(usesCells, ship) == false);
                SetUsesCells(ship, usesCells);
                ships.Add(ship);
                ruleNumber++;
                createdShip++;
            };

            return ships;
        }
        private Point GetRandomPoint()
        {
            var rand = new Random();
            return new Point() { X = rand.Next(1, 11), Y = rand.Next(1, 11) };
        }

        private Orientation GetRandomOrientation()
        {
            var randomValue = new Random().Next(1, 3);
            return (Orientation)randomValue;
        }

        private int GetShipSize() => shipCreationRule[ruleNumber];


        private List<Point> SetUsesCells(Ship ship, List<Point> usesCells)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < ship.size + 1; j++)
                {
                    if (ship.orientation == (Orientation)1)
                    {
                        usesCells.Add(new Point() { X = ship.coorditates[0].X + j, Y = ship.coorditates[0].Y + i });
                    }
                    else
                    {
                        usesCells.Add(new Point() { X = ship.coorditates[0].X + i, Y = ship.coorditates[0].Y + j });
                    }
                }
            }
            return usesCells;
        }

        private bool CheckShipPosition(List<Point> usesCells, Ship ship)
        {
            if (CheckOutOfBattleField(ship) == false)
            {
                return false;
            }

            if (CheckCellsForUses(ship.coorditates[0].X, ship.coorditates[0].Y, usesCells) == false)
            {
                return false;
            }

            if (ship.size == 1)
            {
                return true;
            }

            if (ship.orientation == (Orientation)2)
            {
                if (CheckCellsForUses(ship.coorditates[0].X, ship.coorditates[0].Y + ship.size - 1, usesCells) == false)
                {
                    return false;
                }
            }
            else
            {
                if (CheckCellsForUses(ship.coorditates[0].X + ship.size - 1, ship.coorditates[0].Y, usesCells) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckCellsForUses(int x, int y, List<Point> usesCells)
        {
            foreach (Point cell in usesCells)
            {
                if (cell.X != x || cell.Y != y)
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        private bool CheckOutOfBattleField(Ship ship)
        {
            if (ship.orientation == (Orientation)1 && ship.coorditates[0].X + ship.size > 10)
            {
                return false;
            }
            if (ship.orientation == (Orientation)2 && ship.coorditates[0].Y + ship.size > 10)
            {
                return false;
            }
            return true;
        }
    }
}
