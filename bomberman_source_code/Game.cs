﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Bomberman
{
    #region Main Game
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        /*
         * 0 = air
         * 1 = wall
         * 2 = weak wall
         * 3 = placed bomb
         * 4 = smoke
         * 5 = loaded treasure
         * 6 = loaded exit portal
         */

        public static int[] boardLayout; /*= { 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0 };*/
        public static Block[] gameBoard = new Block[165];

        public static Texture2D textureWall;
        public static Texture2D textureWeakWall;
        public static Texture2D textureTreasure;
        public static Texture2D textureExitPortal;
        public static Texture2D ericTexture;
        public static Texture2D floaterTexture;
        public static Texture2D bombTexture;
        public static Texture2D smokeTexture;

        public SpriteFont mainFont;

        private KeyboardState keyboardState;

        public static GameObject eric;
        public static GameObject floater1;
        public static GameObject floater2;

        public static int FramesPerSecond = 100;

        public Game()
        {
            // Game window settings

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.IsBorderless = true;

            _graphics.PreferredBackBufferWidth = 750;
            _graphics.PreferredBackBufferHeight = 580;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // Load the window

            base.Initialize();

            boardLayout = LevelManager.LoadNewLevel(0);
            Start();
        }

        protected override void LoadContent()
        {
            // Load the textures

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            textureWall = Content.Load<Texture2D>("Wall");
            textureWeakWall = Content.Load<Texture2D>("WeakWall");
            textureTreasure = Content.Load<Texture2D>("Treasure");
            textureExitPortal = Content.Load<Texture2D>("Exit");

            ericTexture = Content.Load<Texture2D>("Eric");
            floaterTexture = Content.Load<Texture2D>("Floater");

            bombTexture = Content.Load<Texture2D>("Bomb");
            smokeTexture = Content.Load<Texture2D>("Explosion");

            mainFont = Content.Load<SpriteFont>("MainFont");
        }

        protected override void Update(GameTime gameTime)
        {
            // Update the game at 100 FPS

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / FramesPerSecond);

            // Get the keyboard input

            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            KeyBinds.KeyboardMovePlayer(keyboardState);
            KeyBinds.KeyboardPlaceBomb(keyboardState);

            // Floater updates

            MoveGameObject.Move(ref floater1, floater1.direction);
            MoveGameObject.Move(ref floater2, floater2.direction);

            FloaterMovement.RandomDirectionChange(ref floater1);
            FloaterMovement.RandomDirectionChange(ref floater2);

            FloaterCollision.CheckForCollision(floater1);
            FloaterCollision.CheckForCollision(floater2);

            // Bomb updates

            Bomb.BombCountdown();

            Bomb.CheckForDeath(ref eric);
            Bomb.CheckForDeath(ref floater1);
            Bomb.CheckForDeath(ref floater2);

            // Structure updates (tresure and exit portal)

            Treasure.CheckForPlayerCollision();
            ExitPortal.CheckForPlayerCollision();

            StructureUpdates.UpdateTextures();
            StructureUpdates.UpdateBoardLayout();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // Go through every block and draw it

            foreach (Block block in gameBoard)
            {
                if (BlockUtilities.GetBlockTypeTexture(block.blockType) != null)
                {
                    _spriteBatch.Draw(BlockUtilities.GetBlockTypeTexture(block.blockType), new Rectangle(new Point((int)block.vector.X, (int)block.vector.Y), new Point(50, 50)), Color.White);
                }
            }

            // Draw Eric and the floaters

            _spriteBatch.Draw(eric.texture, eric.rectangle, Color.White);
            _spriteBatch.Draw(floater1.texture, floater1.rectangle, Color.White);
            _spriteBatch.Draw(floater2.texture, floater2.rectangle, Color.White);

            _spriteBatch.DrawString(mainFont, Score.scoreboard, Score.CalculateScoreBoardPosition(), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public static void Start()
        {
            // Runs after loading the game window
            // Generate a treasure and an exit portal

            Treasure.GenerateTreasure();
            ExitPortal.GenerateExitPortal();

            // Go through boardLayout, and create blocks matching to the numbers

            for (int index = 0; index < 165; index++)
            {
                gameBoard[index] = new Block(VectorMath.CalculateActualVector(index), BlockUtilities.ConvertToBlockType(boardLayout[index]));
            }
        }

        public static void Restart(bool playerDied)
        {
            Bomb.ResetCountdowns();

            Treasure.treasureFound = true;
            ExitPortal.exitPortalFound = true;

            for (int index = 0; index < 165; index++)
            {
                gameBoard[index].ChangeType(BlockType.Air);
            }

            boardLayout = LevelManager.LoadNewLevel(playerDied ? 0 : ++LevelManager.level);

            foreach (int i in boardLayout)
            {
                Console.Write($"{i} ");
            }

            //for (int index = 0; index < 165; index++)
            //{
            //    gameBoard[index] = new Block(VectorMath.CalculateActualVector(index), BlockUtilities.ConvertToBlockType(boardLayout[index]));
            //}
        }
    }
    #endregion
}