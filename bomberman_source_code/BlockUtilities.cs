﻿using Microsoft.Xna.Framework;
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
                case BlockType.Bomb: return Game.bombTexture;
                case BlockType.Smoke: return Game.smokeTexture;
                case BlockType.Treasure: return Game.textureTreasure;
                case BlockType.ExitPortal: return Game.textureExitPortal;
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
            BlockType[] blockTypes = { BlockType.Air, BlockType.Wall, BlockType.WeakWall, BlockType.Bomb, BlockType.Smoke, BlockType.Treasure, BlockType.ExitPortal };
            return blockTypes[number];
        }

        /// <summary>
        /// Update all of the block textures
        /// </summary>
        public static void UpdateAllTextures()
        {
            for (int index = 0; index < 165; index++)
                Game.gameBoard[index] = new Block(VectorMath.CalculateActualVector(index), ConvertToBlockType(Game.boardLayout[index]));
        }

        /// <summary>
        /// Set the boardLayout to the given level
        /// </summary>
        /// <param name="level">Next level</param>
        public static void LoadBoardLayout(int level)
        {
            for (int index = 0; index < 165; index++)
                Game.boardLayout[index] = LevelManager.levels[level][index];
        }
    }

    public enum BlockType
    {
        Air,
        Wall,
        WeakWall,
        Bomb,
        Smoke,
        Treasure,
        ExitPortal,
    }
    #endregion
}
