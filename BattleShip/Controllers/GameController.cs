using BattleShip.Controllers;
using BattleShip.Structures;
using System;
using System.Collections.Generic;

namespace BattleShip.Game
{
    internal class GameController
    {
        public void StartGame(List<Ship> ships)
        {
            Point shotCoord;
            var consoleController = new ConsoleController();
            do
            {
                shotCoord = consoleController.GetCoordinates();
                Shot(ships, shotCoord);
            }
            while (EndGame(ships) == false);
            Console.WriteLine("You WIN!");
            Console.WriteLine("For new game press any key.");
            Console.WriteLine("For exit press Esc");
        }

        private List<Ship> Shot(List<Ship> ships, Point coord)
        {
            foreach (Ship ship in ships)
            {
                for (int i = 0; i < ship.size; i++)
                {
                    if (ship.coorditates[i].X == coord.X && ship.coorditates[i].Y == coord.Y)
                    {
                        ship.HP--;
                        if (ship.HP == 0)
                        {
                            ship.staus = "Destroyed";
                            Console.WriteLine($"Ship was destroyed! The ship had {ship.size} deck(s)");
                        }
                        else
                        {
                            ship.staus = "Hitted";
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
                if (ship.staus.Contains("Whole") || ship.staus.Contains("Hitted"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}