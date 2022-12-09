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
        public static string scoreText = "SCORE: 0";

        public static void Add(int amount)
        {
            score += amount;
            scoreText = $"SCORE: {score}";
        }

        public static void Set(int amount)
        {
            score = amount;
            scoreText = $"SCORE: {score}";
        }
    }
}
