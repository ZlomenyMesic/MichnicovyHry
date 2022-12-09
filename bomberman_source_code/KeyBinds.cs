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
    public static class KeyBinds
    {
        #region KeyBinds
        public static void KeyboardMovePlayer(KeyboardState keyboardState)
        {
            // Move the player if the user presses a key

            if (keyboardState.IsKeyDown(Keys.W)) { GameObjectMove.EricMoveUp(); }
            if (keyboardState.IsKeyDown(Keys.A)) { GameObjectMove.EricMoveLeft(); }
            if (keyboardState.IsKeyDown(Keys.S)) { GameObjectMove.EricMoveDown(); }
            if (keyboardState.IsKeyDown(Keys.D)) { GameObjectMove.EricMoveRight(); }

        }

        public static void KeyboardPlaceBomb(KeyboardState keyboardState)
        {
            // Place a bomb if the user pressed key B

            if (keyboardState.IsKeyDown(Keys.B))
            {
                //Bomb.Place();
            }
        }
        #endregion
    }
}
