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
    #region Eric
    public class Eric : Microsoft.Xna.Framework.Game
    {
        public Vector2 position;
        public Rectangle rectangle;

        public Eric(Vector2 startPos)
        {
            // Eric constructor, create Eric

            position = startPos;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
        }

        public void MoveTo(Vector2 newPos)
        {
            // Move Eric to a new location

            position = newPos;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
        }

        public void Kill()
        {
            // Kill Eric

            Game.ericTexture.Dispose();
        }
    }
    #endregion
}
