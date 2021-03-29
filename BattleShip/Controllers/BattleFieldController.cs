using System;
using System.Collections.Generic;

namespace BattleShip.Controllers
{
    class BattleFieldController
    {
        public void AddShips(List<Ship> ships)
        {
            string[,] bf = new string[10, 10];
            FillValues(bf);
            AddShipToField(bf, ships);
            Print(bf);
        }

        private string[,] AddShipToField(string[,] battleField, List<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                for (int i = 0; i < ship.size; i++)
                {
                    battleField[ship.coorditates[i].X - 1, ship.coorditates[i].Y - 1] = "x";
                }
            }
            return battleField;
        }

        private void FillValues(string[,] bf)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    bf[i, j] =".";
                }
            }
        }

        private void Print(string[,] bf)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0,4}", bf[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

