using BattleShip.ModelHelpers;
using BattleShip.ModelHelpers.Structures;
using System;
using System.Collections.Generic;

namespace BattleShip.Models
{
    class Ship
    {
        public List<Point> Coorditates;

        public int Size;

        public Orientation Orientation;

        public int HP;

        public string Status;

        public Ship(Point coord, int size, Orientation orientation)
        {
            Size = size;
            Orientation = orientation;
            Status = "Whole";
            HP = size;
            if (orientation == Orientation.Horizontal)
            {
                Coorditates = SetHorizontalShipCoordinates(size, coord);
            }
            else
            {
                Coorditates = SetVerticalShipCoordinates(size, coord);
            }
        }

        public string GetStatus(Ship ship) => ship.Status;

        private List<Point> SetHorizontalShipCoordinates(int size, Point coordinate)
        {
            List<Point> tempPoint = new List<Point>();
            for (int i = 0; i < size; i++)
            {
                tempPoint.Add(new Point { X = coordinate.X + i, Y = coordinate.Y });
            }
            return tempPoint;
        }

        private List<Point> SetVerticalShipCoordinates(int size, Point coordinate)
        {
            List<Point> tempPoint = new List<Point>();
            for (int i = 0; i < size; i++)
            {
                tempPoint.Add(new Point { X = coordinate.X, Y = coordinate.Y + i });
            }
            return tempPoint;
        }
    }
}
