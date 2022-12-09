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
    internal static class StructuresUpdate
    {
        public static void UpdateTextures()
        {
            // Load the treasure texture

            if (Game.boardLayout[Treasure.treasurePosition] == 0)
            {
                Treasure.treasureLoadCheck = true;
                Game.gameBoard[Treasure.treasurePosition].ChangeType(BlockType.Treasure);
            }

            // Load the exit portal texture

            if (Game.boardLayout[ExitPortal.exitPortalPosition] == 0)
            {
                ExitPortal.exitPortalLoadCheck = true;
                Game.gameBoard[ExitPortal.exitPortalPosition].ChangeType(BlockType.ExitPortal);
            }
        }

        public static void UpdateBoardLayout()
        {
            // Add the loaded treasure to the board

            if (Treasure.treasureLoadCheck)
            {
                Game.boardLayout[Treasure.treasurePosition] = 5;
                Treasure.treasureLoadCheck = false;
            }

            // Add the loaded exit portal to the board

            if (ExitPortal.exitPortalLoadCheck)
            {
                Game.boardLayout[ExitPortal.exitPortalPosition] = 6;
                ExitPortal.exitPortalLoadCheck = false;
            }
        }
    }
    #endregion
}
