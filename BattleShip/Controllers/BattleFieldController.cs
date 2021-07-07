using BattleShip.Models;
using System;
using System.Collections.Generic;

namespace BattleShip.Controllers
{
    class BattleFieldController
    {
        public void AddShips(List<Ship> ships)
        {
            string[,] battleFiled = new string[10, 10];
            FillValues(battleFiled);
            AddShipToField(battleFiled, ships);
            Print(battleFiled);
        }

        private string[,] AddShipToField(string[,] battleField, List<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    battleField[ship.Coorditates[i].X - 1, ship.Coorditates[i].Y - 1] = "x";
                }
            }
            return battleField;
        }

        private void FillValues(string[,] battleField)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    battleField[i, j] = ".";
                }
            }
        }

        private void Print(string[,] battleField)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0,4}", battleField[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

