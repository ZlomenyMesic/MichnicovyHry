using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    #region Game Level Manager
    internal static class LevelManager
    {
        public static void Death(bool player)
        {
            Score.Add(player ? 0 : 250);
        }
    }
    #endregion
}
