using BattleShip.Controllers;
using BattleShip.ModelHelpers.Structures;
using BattleShip.Models;
using System;
using System.Collections.Generic;

namespace BattleShip.Game
{
    class GameController
    {
        public void StartGame(List<Ship> ships)
        {
            Point shotCoordinates;
            var consoleController = new ConsoleController();

            do
            {
                shotCoordinates = consoleController.GetCoordinates();
                Shot(ships, shotCoordinates);
            }
            while (EndGame(ships) == false);
        }

        private List<Ship> Shot(List<Ship> ships, Point coordinate)
        {
            foreach (Ship ship in ships)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    if (ship.Coorditates[i].X == coordinate.X && ship.Coorditates[i].Y == coordinate.Y)
                    {
                        ship.HP--;
                        if (ship.HP == 0)
                        {
                            ship.Status = "Destroyed";
                            Console.WriteLine($"Ship was destroyed! The ship had {ship.Size} deck(s)");
                        }
                        else
                        {
                            ship.Status = "Hit";
                            Console.WriteLine("Hit!");
                        }
                        return ships;
                    }
                }
            }
            Console.WriteLine("Miss!");
            return ships;
        }

        private bool EndGame(List<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                if (ship.Status.Contains("Whole") || ship.Status.Contains("Hit"))
                {
                    return false;
                }
            }
            Console.WriteLine("You WIN!");
            Console.WriteLine("For new game press any key.");
            Console.WriteLine("For exit press Esc");
            return true;
        }
    }
}