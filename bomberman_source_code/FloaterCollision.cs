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
    #region Floater Collisions
    internal static class FloaterCollision
    {
        /// <summary>
        /// Check for a collision between the player and the floater
        /// </summary>
        /// <param name="floater">Game object reference</param>
        public static void CheckForCollision(GameObject floater) 
        {
            // Calculate the distance between the player and the floater

            int distance = (int)Vector2.Distance(new Vector2(Game.eric.position.X, Game.eric.position.Y), new Vector2(floater.position.X, floater.position.Y));

            if (distance < 30)
            {
                Game.eric.Kill();
            }
        }
    }
    #endregion
}
