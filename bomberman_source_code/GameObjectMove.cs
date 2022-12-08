using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    internal static class GameObjectMove
    {
        #region Moving
        public static void EricMoveUp()
        {
            Game.eric.MoveTo(new Microsoft.Xna.Framework.Vector2(Game.eric.position.X, Game.eric.position.Y - 1));
        }

        public static void EricMoveDown()
        {
            Game.eric.MoveTo(new Microsoft.Xna.Framework.Vector2(Game.eric.position.X, Game.eric.position.Y + 1));
        }

        public static void EricMoveLeft()
        {
            Game.eric.MoveTo(new Microsoft.Xna.Framework.Vector2(Game.eric.position.X - 1, Game.eric.position.Y));
        }

        public static void EricMoveRight()
        {
            Game.eric.MoveTo(new Microsoft.Xna.Framework.Vector2(Game.eric.position.X + 1, Game.eric.position.Y));
        }
        #endregion
    }
}
