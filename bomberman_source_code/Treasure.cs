using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bomberman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Bomberman
{
    #region Treasure
    public static class Treasure
    {
        public static int treasurePosition;
        public static bool treasureFound = false;
        public static bool treasureLoadCheck = false;

        public static void GenerateTreasure()
        {
            // List all the weak walls, then choose one and make it a treasure

            Random random = new Random();
            List<int> possibleBlocks = new List<int>();

            for (int index = 0; index < 165; index++)
            {
                if (Game.boardLayout[index] == 2)
                {
                    possibleBlocks.Add(index);
                }
            }
            treasurePosition = possibleBlocks[random.Next(0, possibleBlocks.Count - 1)];
        }

        public static void Collected()
        {
            // Erase the treasure and add score 500

            if (!treasureFound)
            {
                treasureFound = true;
                Game.gameBoard[treasurePosition].ChangeType(BlockType.Air);
                Score.Add(500);
            }
        }

        public static void CheckForPlayerCollision()
        {
            // Check if the player is touching the treasure

            Vector2 gameObjectCoordinates = VectorMath.DivideVector(new Vector2(Game.eric.position.X + 25, Game.eric.position.Y + 25));

            for (int index = 0; index < 165; index++)
            {
                if ((Game.boardLayout[index] == 5) && (index == VectorMath.CalculateBoardRelativePosition(gameObjectCoordinates)))
                {
                    Treasure.Collected();
                }
            }
        }
    }
    #endregion
}
