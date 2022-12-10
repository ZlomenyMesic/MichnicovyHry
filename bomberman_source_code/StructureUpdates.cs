using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bomberman;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    #region Structure Updates
    internal static class StructureUpdates
    {
        /// <summary>
        /// Update the treasure and exit portal textures
        /// </summary>
        public static void UpdateTextures()
        {
            if ((Game.boardLayout[Treasure.treasurePosition] == 0) && !Treasure.treasureFound)
            {
                // Load the treasure texture

                Treasure.treasureLoadCheck = true;
                Game.gameBoard[Treasure.treasurePosition].ChangeType(BlockType.Treasure);
            }

            if ((Game.boardLayout[ExitPortal.exitPortalPosition] == 0) && !ExitPortal.exitPortalFound)
            {
                // Load the exit portal texture

                ExitPortal.exitPortalLoadCheck = true;
                Game.gameBoard[ExitPortal.exitPortalPosition].ChangeType(BlockType.ExitPortal);
            }
        }

        /// <summary>
        /// Add the loaded treasure or exit portal to the boardLayout
        /// </summary>
        public static void UpdateBoardLayout()
        {
            if (Treasure.treasureLoadCheck)
            {
                // Add the loaded treasure to the board

                Game.boardLayout[Treasure.treasurePosition] = 5;
                Treasure.treasureLoadCheck = false;
            }

            if (ExitPortal.exitPortalLoadCheck)
            {
                // Add the loaded exit portal to the board

                Game.boardLayout[ExitPortal.exitPortalPosition] = 6;
                ExitPortal.exitPortalLoadCheck = false;
            }
        }
    }
    #endregion
}
