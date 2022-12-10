using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bomberman;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Bomberman
{
    #region Game Level Manager
    internal static class LevelManager
    {
        public static int level = 0;
        public static List<int[]> levels = new List<int[]>
        {
            new int[] { 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0 },
            new int[] { 0, 0, 0, 0, 0, 2, 0, 2, 0, 2, 0, 0, 0, 0, 0,
 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,
 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
 2, 1, 2, 1, 0, 1, 2, 1, 2, 1, 0, 1, 2, 1, 2,
 0, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 0,
 2, 1, 2, 1, 0, 1, 2, 1, 2, 1, 0, 1, 2, 1, 2,
 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0,
 2, 1, 2, 1, 0, 1, 2, 1, 2, 1, 0, 1, 2, 1, 2,
 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,
 0, 0, 0, 0, 0, 2, 0, 2, 0, 2, 0, 0, 0, 0, 0 },
            new int[] { 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2,
 2, 1, 0, 1, 2, 1, 2, 1, 2, 1, 2, 1, 0, 1, 2,
 2, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 2,
 2, 1, 0, 1, 0, 1, 2, 1, 2, 1, 0, 1, 0, 1, 2,
 2, 2, 0, 2, 0, 2, 0, 0, 0, 2, 0, 2, 0, 2, 2,
 2, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 2,
 2, 2, 0, 2, 0, 2, 0, 0, 0, 2, 0, 2, 0, 2, 2,
 2, 1, 0, 1, 0, 1, 2, 1, 2, 1, 0, 1, 0, 1, 2,
 2, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 2,
 2, 1, 0, 1, 2, 1, 2, 1, 2, 1, 2, 1, 0, 1, 2,
 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2 }

        };
        public static bool preventMultipleRestarts = true;

        public static void Death(bool player)
        {
            Score.Add(player ? 0 : 250);

            if (player && preventMultipleRestarts) 
            {
                preventMultipleRestarts= false;
                Console.WriteLine("death ok");
                Game.Restart(true);
            }
        }

        public static int[] LoadNewLevel(int newLevel)
        {
            Console.WriteLine($"{newLevel}");
            if (newLevel == 0)
            {
                Console.WriteLine("OK");
                Game.eric = new(new Vector2(600, 530), true);
                Game.floater1 = new(new Vector2(150, 230), false);
                Game.floater2 = new(new Vector2(550, 230), false);
                return levels[0];
            }
            else if (newLevel == 1)
            {
                Game.eric = new(new Vector2(600, 530), true);
                Game.floater1 = new(new Vector2(200, 280), false);
                Game.floater2 = new(new Vector2(500, 280), false);
                return levels[1];
            }
            else if (newLevel == 2)
            {
                Game.eric = new(new Vector2(600, 530), true);
                Game.floater1 = new(new Vector2(350, 30), false);
                Game.floater2 = new(new Vector2(350, 430), false);
                return levels[2];
            }
            else
            {
                Console.WriteLine("NOT OK");
                return levels[2];
            }
        }
    }
    #endregion
}
