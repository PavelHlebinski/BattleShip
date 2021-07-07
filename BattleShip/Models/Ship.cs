using BattleShip.ModelHelpers;
using BattleShip.ModelHelpers.Structures;
using System.Collections.Generic;

namespace BattleShip.Models
{
    class Ship
    {
        public List<Point> Coorditates;

        public int Size;

        public Orientation Orientation;

        private int HP { get; set; }

        public Ship(Point coordinates, int size, Orientation orientation)
        {
            Size = size;
            Orientation = orientation;
            HP = size;
            if (orientation == Orientation.Horizontal)
            {
                Coorditates = SetHorizontalShipCoordinates(size, coordinates);
            }
            else
            {
                Coorditates = SetVerticalShipCoordinates(size, coordinates);
            }
        }

        public int GetHP(Ship ship) => ship.HP;

        public void SetHP(int hp) => HP = hp;

        private List<Point> SetHorizontalShipCoordinates(int size, Point coordinate)
        {
            List<Point> tempPoint = new List<Point>();
            for (int i = 0; i < size; i++)
            {
                tempPoint.Add(new Point
                {
                    X = coordinate.X + i,
                    Y = coordinate.Y
                });
            }
            return tempPoint;
        }

        private List<Point> SetVerticalShipCoordinates(int size, Point coordinate)
        {
            List<Point> tempPoint = new List<Point>();
            for (int i = 0; i < size; i++)
            {
                tempPoint.Add(new Point
                {
                    X = coordinate.X,
                    Y = coordinate.Y + i
                });
            }
            return tempPoint;
        }
    }
}
