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
    internal static class FloaterCollision
    {
        public static void CheckForCollision(GameObject floater) 
        {
            // Check for a collision between the player and a floater
            // bool floater: true = floater1, false = floater2

            int distance = (int)Vector2.Distance(new Vector2(Game.eric.position.X, Game.eric.position.Y), new Vector2(floater.position.X, floater.position.Y));

            if (distance < 30)
            {
                Game.eric.Kill();
            }
        }
    }
}
