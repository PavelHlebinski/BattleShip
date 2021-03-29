using BattleShip.Structures;
using System;
using System.Collections.Generic;

namespace BattleShip
{
    internal enum Orientation
    {
        Vertical = 2,
        Horizontal = 1
    }
    internal class Ship
    {

        public List<Point> coorditates;

        public int size;

        public Orientation orientation;

        public int HP;

        public string staus;


        public Ship(Point coord, int size, Orientation orientation)
        {
            this.size = size;
            this.orientation = orientation;
            staus = "Whole";
            HP = size;
            if (orientation == (Orientation)1)
            {
                coorditates = SetVerticalShipCoordinates(size, coord);
            }
            else
            {
                coorditates = SetHorizontalShipCoordinates(size, coord);
            }
        }

        public string GetStatus(Ship ship) => ship.staus;

        public int GetHP(Ship ship) => ship.HP;

        public void PrintCoordinates()
        {
            foreach (Point coordinate in coorditates)
            {
                Console.WriteLine($"X: {coordinate.X} Y: {coordinate.Y}");
            }
            Console.WriteLine(" ");
        }

        private List<Point> SetHorizontalShipCoordinates(int size, Point coordinate)
        {
            List<Point> tempPoint = new List<Point>();
            for (int i = 0; i < size; i++)
            {
                tempPoint.Add(new Point() { X = coordinate.X, Y = coordinate.Y + i });
            }
            return tempPoint;
        }

        private List<Point> SetVerticalShipCoordinates(int size, Point coordinate)
        {
            List<Point> tempPoint = new List<Point>();
            for (int i = 0; i < size; i++)
            {
                tempPoint.Add(new Point() { X = coordinate.X + i, Y = coordinate.Y });
            }
            return tempPoint;
        }
    }
}
