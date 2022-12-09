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
    public static class ExitPortal
    {
        public static int exitPortalPosition;
        public static bool exitPortalFound = false;
        public static bool exitPortalLoadCheck = false;

        public static void GenerateExitPortal()
        {
            // List all the weak walls, then choose one and make it an exit portal
            // If the exit portal location matches treasure location, don't put it there

            Random random = new Random();
            List<int> possibleBlocks = new List<int>();

            for (int index = 0; index < 165; index++)
            {
                if ((Game.boardLayout[index] == 2) && (index != Treasure.treasurePosition))
                {
                    possibleBlocks.Add(index);
                }
            }
            exitPortalPosition = possibleBlocks[random.Next(0, possibleBlocks.Count - 1)];
        }

        public static void PortalEntered()
        {
            if (exitPortalFound)
            {
                exitPortalFound = true;
                Game.gameBoard[exitPortalPosition].ChangeType(BlockType.Air);
            }
        }

        public static void CheckForPlayerCollision()
        {
            // Check if the player entered the exit portal

            Vector2 gameObjectCoordinates = VectorMath.DivideVector(new Vector2(Game.eric.position.X + 25, Game.eric.position.Y + 25));

            for (int index = 0; index < 165; index++)
            {
                if ((Game.boardLayout[index] == 5) && (index == VectorMath.CalculateBoardRelativePosition(gameObjectCoordinates)))
                {
                    ExitPortal.PortalEntered();
                }
            }
        }
    }
}
