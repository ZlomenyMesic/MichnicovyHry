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
    static class Score
    {
        public static int score = 0;
        public static string scoreBoard = "SCORE: 0";
        private static Vector2 scoreBoardPosition;

        public static void Add(int amount)
        {
            score += amount;
            scoreBoard = $"SCORE: {score}";
        }

        public static void Set(int amount)
        {
            score = amount;
            scoreBoard = $"SCORE: {score}";
        }

        public static Vector2 CalculateScoreBoardPosition()
        {
            int scoreLength = score.ToString().Length;
            if (scoreLength == 1) { return new Vector2(330, 5); }
            else if (scoreLength == 3) { return new Vector2(320, 5); }
            else if (scoreLength == 4) { return new Vector2(315, 5); }
            return new Vector2(0, 0);
        }
    }
}
