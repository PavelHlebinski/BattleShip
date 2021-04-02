using BattleShip.Controllers;
using BattleShip.Game;
using System;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                var shipController = new ShipsController();
                var ships = shipController.CreateShips();
                var battleFieldController = new BattleFieldController();
                battleFieldController.AddShips(ships);
                var game = new GameController();
                game.StartGame(ships);
            }
            while (Console.ReadKey().Key == ConsoleKey.Escape);
        }
    }
}
