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

        public void ChangeType(BlockType newBlockType)
        {
            blockType = newBlockType;
        }
    }
    #endregion
}

