using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bomberman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;

namespace Bomberman
{
    internal static class MoveGameObject
    {
        #region Moving
        public static void Move(ref GameObject gameObject, Direction direction)
        {
            GetDirectionCoords(direction, out int move_X, out int move_Y, out int add_X1, out int addY1, out int addX2, out int addY2);

            // Get the game object coordinates

            Vector2 topLeft = VectorMath.DivideVector(new Vector2(gameObject.position.X + add_X1, gameObject.position.Y + addY1));
            Vector2 bottomRight = VectorMath.DivideVector(new Vector2(gameObject.position.X + addX2, gameObject.position.Y + addY2));

            Vector2 newCoordsTop = new Vector2(topLeft.X + move_X, topLeft.Y + move_Y);
            Vector2 newCoordsBottom = new Vector2(bottomRight.X + move_X, bottomRight.Y + move_Y);

            // Check if the blocks the game object wants to move to are free

            if (!BlockStates.IsOutOfRange(newCoordsTop) && !BlockStates.IsOutOfRange(newCoordsBottom)
                && BlockStates.CanBeWalkedThrough(newCoordsTop) && BlockStates.CanBeWalkedThrough(newCoordsBottom))
            {
                gameObject.MoveTo(new Vector2(gameObject.position.X + move_X, gameObject.position.Y + move_Y));
            }
            else if (!gameObject.isPlayer)
            {
                // Change the floater's direction when it hits a wall

                FloaterMovement.ChangeDirection(ref gameObject, direction);
            }
        }
        #endregion

        private static void GetDirectionCoords(Direction direction, out int move_X, out int move_Y, out int addX1, out int addY1, out int addX2, out int addY2)
        {
            // Convert a simple direction to a direction with coordinates

            move_X = 0; move_Y = 0; addX1 = 0; addY1 = 0; addX2 = 0; addY2 = 0;

            switch (direction)
            {
                case Direction.Up: move_X = 0; move_Y = -1; addX1 = 2; addY1 = 50; addX2 = 48; addY2 = 50; break;
                case Direction.Down: move_X = 0; move_Y = 1; addX1 = 2; addY1 = 0; addX2 = 48; addY2 = 0; break;
                case Direction.Left: move_X = -1; move_Y = 0; addX1 = 50; addY1 = 2; addX2 = 50; addY2 = 48; break;
                case Direction.Right: move_X = 1; move_Y = 0; addX1 = 0; addY1 = 2; addX2 = 0; addY2 = 48; break;
            }
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left, 
        Right
    }
}
