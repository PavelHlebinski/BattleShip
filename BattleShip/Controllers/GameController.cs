using BattleShip.ModelHelpers.Structures;
using BattleShip.Models;
using System;
using System.Collections.Generic;

namespace BattleShip.Controllers
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
            while (!EndGame(ships));
        }

        private List<Ship> Shot(List<Ship> ships, Point coordinate)
        {
            foreach (Ship ship in ships)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    if (ship.Coorditates[i].X == coordinate.X && ship.Coorditates[i].Y == coordinate.Y)
                    {
                        var shipHP = ship.GetHP(ship) - 1;
                        if (shipHP == 0)
                        {
                            Console.WriteLine($"Ship was destroyed! The ship had {ship.Size} deck(s)");
                        }
                        else
                        {
                            Console.WriteLine("Hit!");
                        }
                        ship.SetHP(shipHP);
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
                var shipHP = ship.GetHP(ship);
                if (shipHP != 0)
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