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
    internal class VectorMath : Microsoft.Xna.Framework.Game
    {
        #region VectorMath
        public static int CalculateBoardPosition(Vector2 vector)
        {
            // Convert XY coordinates to a single number

            return (int)((((vector.Y / 50) - 1) * 15) + (vector.X / 50) - 1);
        }

        public static Vector2 CalculateBoardVector(int boardPosition)
        {
            // Convert a single number to XY board relative coordinates

            int x = (boardPosition % 15) + 1;
            int y = (boardPosition + 15 - (boardPosition % 15)) / 15;
            return new Vector2(x, y);
        }

        public static Vector2 CalculateActualVector(int boardPosition)
        {
            // Convert a single number to XY window relative coordinates

            int x = (boardPosition % 15) + 1;
            int y = (boardPosition + 15 - (boardPosition % 15)) / 15;
            return new Vector2((x - 1) * 50, (y - 1) * 50 + 30);
        }
        #endregion
    }
}
