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
    internal class FloaterMovement
    {
        public static void ChangeDirection(ref GameObject floater, Direction currentDirection)
        {
            // Choose a new direction for the floater

            Random random = new();
            Direction[] directions = { Direction.Up, Direction.Down, Direction.Left, Direction.Right};
            directions = directions.Where(direction => direction != currentDirection).ToArray();
            Direction newDirection = directions[random.Next(0, 3)];

            floater.direction = newDirection;
        }

        public static void RandomDirectionChange(ref GameObject floater)
        {
            // 0.5% chance that a floater will change it's direction

            Random random = new Random();
            if (random.Next(0, 200) == 1)
            {
                ChangeDirection(ref floater, floater.direction);
            }
            else if (random.Next(0, 200) == 2)
            {
                ChangeDirection(ref floater, floater.direction);
            }
        }
    }
}
