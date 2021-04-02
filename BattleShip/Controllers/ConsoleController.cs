using BattleShip.ModelHelpers.Structures;
using System;
using System.Collections.Generic;

namespace BattleShip.Controllers
{
    class ConsoleController
    {
        readonly Dictionary<char, char> goodCoordinates = new Dictionary<char, char>()
        {
             {'a', '1' },
             {'b', '2' },
             {'c', '3' },
             {'d', '4' },
             {'e', '5' },
             {'f', '6' },
             {'g', '7' },
             {'h', '8' },
             {'i', '9' },
             {'j', '1' },
        };

        private string _enteredString;

        public Point GetCoordinates()
        {
            do
            {
                Console.WriteLine("Enter coordinate: ");
                _enteredString = Console.ReadLine().ToLower();
            }
            while (!IsCoordinatesCorrect(_enteredString));

            if (_enteredString.Length == 3)
            {
                return new Point
                {
                    X = 10,
                    Y = GetY(_enteredString[0]),
                };
            }
            return new Point
            {
                X = GetX(_enteredString[1]),
                Y = GetY(_enteredString[0]),
            };
        }

        private int GetY(char coordinate) => Convert.ToInt32(coordinate) - 96;

        private int GetX(char coordinate) => Convert.ToInt32(coordinate) - 48;

        private bool IsCoordinatesCorrect(string coordinates)
        {
            coordinates.ToCharArray();
            if (!IsLenghtCorrect(coordinates) || !IsLetterCorrect(coordinates[0]) || !IsNumberCorrect(coordinates[1]))
            {
                Console.WriteLine("Incorrect coordinates!");
                return false;
            }
            if (coordinates.Length == 3)
            {
                if (coordinates[1] != '1' || coordinates[2] != '0')
                {
                    Console.WriteLine("Incorrect coordinates!");
                    return false;
                }
            }
            return true;
        }

        private bool IsLetterCorrect(char coordinate) => goodCoordinates.ContainsKey(coordinate);

        private bool IsNumberCorrect(char coordinate) => goodCoordinates.ContainsValue(coordinate);

        private bool IsLenghtCorrect(string coordinates)
        {
            if (coordinates.Length > 3 || coordinates.Length <= 1)
            {
                return false;
            }
            return true;
        }
    }
}

