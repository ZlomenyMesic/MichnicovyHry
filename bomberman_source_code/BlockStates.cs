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
    internal class BlockStates
    {
        #region BlockChecking
        public static bool IsFree(Vector2 vector)
        {
            // Check if the block at the given coordinates is empty

            return Game.boardLayout[VectorMath.CalculateBoardPosition(vector)] == 0 ;
        }

        public static bool IsOutOfRange(Vector2 vector)
        {
            // Check if the given coordinates are outside the board

            return ((vector.X / 50) > 15) || ((vector.X / 50) < 1) || ((vector.Y / 50) > 11) || ((vector.Y / 50) < 1);
        }

        public static bool IsBomb(Vector2 vector)
        {
            // Check if the block at the given coordinates is a bomb

            return Game.boardLayout[VectorMath.CalculateBoardPosition(vector)] == 3;
        }

        public static bool IsDestructable(Vector2 vector)
        {
            // Check if the block at the given coordinates is a weak brick

            return Game.boardLayout[VectorMath.CalculateBoardPosition(vector)] == 2;
        }

        public static bool CanExplode(Vector2 vector)
        {
            // Check if the block at the given coordinates can be exploded

            return !IsOutOfRange(vector) && (IsFree(vector) || IsDestructable(vector));
        }

        public static bool CanBeWalkedThrough(Vector2 vector)
        {
            // Check if the block at the given coordinates isn't a wall

            int num = Game.boardLayout[VectorMath.CalculateBoardPosition(vector)];
            return (num == 0) || (num == 3) || (num == 4) || (num == 5) || (num == 6);
        }
        #endregion
    }
}
