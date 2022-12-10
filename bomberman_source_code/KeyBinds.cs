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
        /// <summary>
        /// Move the player if the keys WASD are pressed
        /// </summary>
        /// <param name="keyboardState">Actual keyboard state</param>
        public static void KeyboardMovePlayer(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.W)) { MoveGameObject.Move(ref Game.eric, Direction.Up); }
            if (keyboardState.IsKeyDown(Keys.A)) { MoveGameObject.Move(ref Game.eric, Direction.Left); }
            if (keyboardState.IsKeyDown(Keys.S)) { MoveGameObject.Move(ref Game.eric, Direction.Down); }
            if (keyboardState.IsKeyDown(Keys.D)) { MoveGameObject.Move(ref Game.eric, Direction.Right); }

        }

        /// <summary>
        /// Place a bomb if the key B is pressed
        /// </summary>
        /// <param name="keyboardState">The actual keyboard state</param>
        public static void KeyboardPlaceBomb(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.B))
                Bomb.Place();
        }
    }
    #endregion
}
