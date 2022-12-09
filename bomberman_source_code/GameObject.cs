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
    #region Game Objects
    public class GameObject
    {
        public Vector2 position;
        public Rectangle rectangle;
        public Texture2D texture;
        public Direction direction = Direction.Down;
        public bool isPlayer;

        public GameObject(Vector2 startPos, bool player)
        {
            // Game object constructor, create Eric or floaters

            position = startPos;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
            texture = player ? Game.ericTexture : Game.floaterTexture;
            isPlayer = player;
        }

        public void MoveTo(Vector2 newPos)
        {
            // Move Eric to a new location

            position = newPos;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
        }

        public void Kill()
        {
            // Kill game object

            this.MoveTo(new Vector2(9999999, 9999999));
            LevelManager.Death(isPlayer);
        }
    }
    #endregion
}
