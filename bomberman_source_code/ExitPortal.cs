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
    #region Exit Portal
    public static class ExitPortal
    {
        public static int exitPortalPosition;
        public static bool exitPortalFound = false;
        public static bool exitPortalLoadCheck = false;

        /// <summary>
        /// List all weak walls, then choose one and hide the exit portal inside
        /// </summary>
        public static void GenerateExitPortal()
        {
            exitPortalFound = false;
            exitPortalLoadCheck = false;

            List<int> possibleBlocks = new List<int>();

            for (int index = 0; index < 165; index++)
            {
                // Prevent hiding the exit portal at the same block as the treasure

                if ((Game.boardLayout[index] == 2) && (index != Treasure.treasurePosition))
                {
                    possibleBlocks.Add(index);
                }
            }
            exitPortalPosition = possibleBlocks[new Random().Next(0, possibleBlocks.Count - 1)];
        }

        /// <summary>
        /// Load new level after the player entered the exit portal
        /// </summary>
        public static void PortalEntered()
        {
            // TODO: Load another level

            if (exitPortalFound)
            {
                exitPortalFound = true;
                Game.gameBoard[exitPortalPosition].ChangeType(BlockType.Air);
            }
        }

        /// <summary>
        /// Check if the player entered the exit portal
        /// </summary>
        public static void CheckForPlayerCollision()
        {
            Vector2 ericCoordinates = VectorMath.DivideVector(new Vector2(Game.eric.position.X + 25, Game.eric.position.Y + 25));

            for (int index = 0; index < 165; index++)
            {
                // If the player is standing at the same block as the treasure, call ExitPortal.PortalEntered()

                if ((Game.boardLayout[index] == 6) && (index == VectorMath.CalculateBoardRelativePosition(ericCoordinates)))
                {
                    ExitPortal.PortalEntered();
                }
            }
        }
    }
    #endregion
}