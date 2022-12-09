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
    #region Block
    public class Block
    {
        public Vector2 vector;
        public BlockType blockType;

        public Block(Vector2 newVector, BlockType newBlockType)
        {
            // Block constructor, create a new block

            vector = newVector;
            blockType = newBlockType;
        }

        public void ClearBlock()
        {
            // Set the block to air

            Game.boardLayout[VectorMath.CalculateBoardPosition(vector)] = 0;
            blockType = BlockType.Air;
        }
    }

    public static class BlockHelper
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
                default: return null;
            }
        }

        public static BlockType ConvertToBlockType(int number)
        {
            // Convert numbers to a BlockType

            BlockType[] blockTypes = { BlockType.Air, BlockType.Wall, BlockType.WeakWall, BlockType.Treasure, BlockType.ExitPortal };
            return blockTypes[number];
        }
    }

    public enum BlockType
    {
        Air,
        Wall,
        WeakWall,
        Treasure,
        ExitPortal
    }
    #endregion
}

