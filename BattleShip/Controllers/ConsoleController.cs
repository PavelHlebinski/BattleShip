using BattleShip.Structures;
using System;
using System.Collections.Generic;

namespace BattleShip.Controllers
{
    class ConsoleController
    {
        Dictionary<string, string> goodCoordinates = new Dictionary<string, string>()
        {
             {"a", "1" },
             {"b", "2" },
             {"c", "3" },
             {"d", "4" },
             {"e", "5" },
             {"f", "6" },
             {"g", "7" },
             {"h", "8" },
             {"i", "9" },
             {"j", "10" },
        };

        public Point GetCoordinates()
        {
            string coordinates;
            do
            {
                Console.WriteLine("Enter coordinate: ");
                coordinates = Console.ReadLine();
            }
            while (CheckCoordiates(coordinates) == false);
            return new Point() { X = GetX(coordinates[1].ToString()), Y = GetY(coordinates[0].ToString()) };
        }

        private int GetY(string coordinate) => Convert.ToInt32(goodCoordinates[coordinate]);

        private int GetX(string coordinate) => Convert.ToInt32(coordinate);

        private bool CheckCoordiates(string coordinates)
        {
            if (CheckLetterCoordiate(coordinates[0].ToString()) == false || CheckNumberCoordiate(coordinates[1].ToString()) == false)
            {
                Console.WriteLine("Incorrect coordinates!");
                return false;
            }
            if (coordinates.Length == 3 && CheckForBigNumber(coordinates[2].ToString()) == false)
            {
                Console.WriteLine("Incorrect coordinates!");
                return false;
            }
            return true;
        }

        private bool CheckLetterCoordiate(string coordinate) => goodCoordinates.ContainsKey(coordinate);

        private bool CheckNumberCoordiate(string coordinate) => goodCoordinates.ContainsValue(coordinate);

        private bool CheckForBigNumber(string coordinate)
        {
            return coordinate switch
            {
                "0" => true,
                _ => false
            };
        }
    }
}

