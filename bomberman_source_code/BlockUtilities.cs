using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bomberman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    #region Block Helper
    public static class BlockUtilities
    {
        public static Texture2D GetBlockTypeTexture(BlockType blockType)
        {
            // Return block textures from a BlockType

            switch (blockType)
            {
                case BlockType.Air: return null;
                case BlockType.Wall: return Game.textureWall;
                case BlockType.WeakWall: return Game.textureWeakWall;
                case BlockType.Treasure: return Game.textureTreasure;
                case BlockType.ExitPortal: return Game.textureExitPortal;
                case BlockType.Bomb: return Game.bombTexture;
                case BlockType.Smoke: return Game.smokeTexture;
                default: return null;
            }
        }

        public static BlockType ConvertToBlockType(int number)
        {
            // Convert numbers to a BlockType

            BlockType[] blockTypes = { BlockType.Air, BlockType.Wall, BlockType.WeakWall, BlockType.Treasure, BlockType.ExitPortal, BlockType.Bomb, BlockType.Smoke };
            return blockTypes[number];
        }

        public static void UpdateAllBlockTextures()
        {

        }
    }

    public enum BlockType
    {
        Air,
        Wall,
        WeakWall,
        Treasure,
        ExitPortal,
        Bomb,
        Smoke
    }
    #endregion
}
