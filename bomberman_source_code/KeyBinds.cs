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
    #region Keyboard
    public static class KeyBinds
    {
        public static void KeyboardMovePlayer(KeyboardState keyboardState)
        {
            // Move the player if the user presses a key

            if (keyboardState.IsKeyDown(Keys.W)) { MoveGameObject.Move(ref Game.eric, Direction.Up); }
            if (keyboardState.IsKeyDown(Keys.A)) { MoveGameObject.Move(ref Game.eric, Direction.Left); }
            if (keyboardState.IsKeyDown(Keys.S)) { MoveGameObject.Move(ref Game.eric, Direction.Down); }
            if (keyboardState.IsKeyDown(Keys.D)) { MoveGameObject.Move(ref Game.eric, Direction.Right); }

        }

        public static void KeyboardPlaceBomb(KeyboardState keyboardState)
        {
            // Place a bomb if the user pressed key B

            if (keyboardState.IsKeyDown(Keys.B))
            {
                Bomb.Place();
            }
        }
    }
    #endregion
}
