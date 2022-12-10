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
        /// <summary>
        /// Get the texture for the block type
        /// </summary>
        /// <param name="blockType">The block type</param>
        /// <returns>The texture for the given block type</returns>
        public static Texture2D GetBlockTypeTexture(BlockType blockType)
        {
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

        /// <summary>
        /// Get the block type from a block ID
        /// </summary>
        /// <param name="number">Block ID</param>
        /// <returns>BlockType matching the given ID</returns>
        public static BlockType ConvertToBlockType(int number)
        {
            BlockType[] blockTypes = { BlockType.Air, BlockType.Wall, BlockType.WeakWall, BlockType.Treasure, BlockType.ExitPortal, BlockType.Bomb, BlockType.Smoke };
            return blockTypes[number];
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
