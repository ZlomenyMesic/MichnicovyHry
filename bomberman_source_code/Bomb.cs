using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bomberman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;
using System.IO;

namespace Bomberman
{
    static class Bomb
    {
        private static int bombCountdown = -1;
        private static bool preventBombPlacement = false;

        public static void Place()
        {
            // Place a bomb on the player

            Vector2 ericCoords = VectorMath.DivideVector(new Vector2(Game.eric.position.X + 25, Game.eric.position.Y + 25));

            if (!BlockStates.IsOutOfRange(ericCoords) && BlockStates.IsFree(ericCoords) && !BlockStates.IsBomb(ericCoords) && (bombCountdown == -1))
            {
                bombCountdown = 165;
                Game.boardLayout[VectorMath.CalculateBoardRelativePosition(ericCoords)] = 3;
                Game.gameBoard[VectorMath.CalculateBoardRelativePosition(ericCoords)].ChangeType(BlockType.Bomb);
            }
        }

        private static List<int> Radius(int pos)
        {
            // Counts the explosion radius around the given position
            // Returns a list with all the possible blocks

            List<int> destructableBlocks = new List<int>();
            Vector2 bombPos = VectorMath.CalculateBoardVector(pos);

            // 2 blocks left
            for (int index = (int)bombPos.X - 1; index > bombPos.X - 3; index--)
            {
                if (BlockStates.CanExplode(new Vector2(index, bombPos.Y)))
                {
                    destructableBlocks.Add(VectorMath.CalculateBoardRelativePosition(new Vector2(index, bombPos.Y)));
                }
                else { break; }
            }

            // 2 blocks right
            for (int index = (int)bombPos.X + 1; index < bombPos.X + 3; index++)
            {
                if (BlockStates.CanExplode(new Vector2(index, bombPos.Y)))
                {
                    destructableBlocks.Add(VectorMath.CalculateBoardRelativePosition(new Vector2(index, bombPos.Y)));
                }
                else { break; }
            }

            // 2 blocks up
            for (int index = (int)bombPos.Y - 1; index > bombPos.Y - 3; index--)
            {
                if (BlockStates.CanExplode(new Vector2(bombPos.X, index)))
                {
                    destructableBlocks.Add(VectorMath.CalculateBoardRelativePosition(new Vector2(bombPos.X, index)));
                }
                else { break; }
            }

            // 2 blocks down
            for (int index = (int)bombPos.Y + 1; index < bombPos.Y + 3; index++)
            {
                if (BlockStates.CanExplode(new Vector2(bombPos.X, index)))
                {
                    destructableBlocks.Add(VectorMath.CalculateBoardRelativePosition(new Vector2(bombPos.X, index)));
                }
                else { break; }
            }

            destructableBlocks.Add(VectorMath.CalculateBoardRelativePosition(bombPos));
            return destructableBlocks;
        }

        private static void Explosion()
        {
            // Create the smoke effect

            bombCountdown = -1;
            for (int index = 0; index < 165; index++)
            {
                if (Game.boardLayout[index] == 3)
                {
                    foreach (int position in Radius(index))
                    {
                        Game.gameBoard[position].ChangeType(BlockType.Smoke);
                        Game.boardLayout[position] = 4;
                    }
                    break;
                }
            }
        }

        private static void ClearExplosion()
        {
            // Remove the smoke effect

            for (int index = 0; index < 165; index++)
            {
                if (Game.boardLayout[index] == 4)
                {
                    Game.gameBoard[index].ChangeType(BlockType.Air);
                    Game.boardLayout[index] = 0;
                }
            }
        }

        public static void BombCountdown()
        {
            // Runs 80 times per second
            // bombCheck is -1 if there is no bomb

            if (Game.boardLayout.Contains(4))
            {
                // If a bomb has exploded, count down from 60 and then clear the smoke

                if ((bombCountdown <= 0) && !preventBombPlacement)
                {
                    preventBombPlacement = true;
                    bombCountdown = 60;
                }
                else { bombCountdown--; }

                if (bombCountdown == 0)
                {
                    preventBombPlacement = false;
                    ClearExplosion();
                }
            }
            else
            {
                // If a bomb is placed, count down from 45 and then explode

                if (bombCountdown != -1) { bombCountdown--; }
                if (bombCountdown == 0) { Explosion(); }
            }
        }

        public static void CheckForDeath(ref GameObject gameObject)
        {
            // Go through every smoke block, and check if the game object is touching it

            Vector2 gameObjectCoordinates = VectorMath.DivideVector(new Vector2(gameObject.position.X + 25, gameObject.position.Y + 25));
            
            for (int index = 0; index < 165; index++)
            {
                if ((Game.boardLayout[index] == 4) && (index == VectorMath.CalculateBoardRelativePosition(gameObjectCoordinates)))
                {
                    gameObject.Kill();
                }
            }
        }
    }
}
