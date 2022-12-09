using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Bomberman
{
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

        public static int[] boardLayout = { 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0,
 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0 };
        public static Block[] gameBoard = new Block[165];

        public static Texture2D textureWall;
        public static Texture2D textureWeakWall;
        public static Texture2D textureTreasure;
        public static Texture2D textureExitPortal;
        public static Texture2D ericTexture;

        public SpriteFont mainFont;

        private KeyboardState keyboardState;

        public static Eric eric;


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

            mainFont = Content.Load<SpriteFont>("MainFont");
        }

        protected override void Update(GameTime gameTime)
        {
            // Update the game at 60 FPS

            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            KeyBinds.KeyboardMovePlayer(keyboardState);
            KeyBinds.KeyboardPlaceBomb(keyboardState);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // Go through every block and draw it

            foreach (Block block in gameBoard)
            {
                if (BlockHelper.GetBlockTypeTexture(block.blockType) != null)
                {
                    _spriteBatch.Draw(BlockHelper.GetBlockTypeTexture(block.blockType), new Rectangle(new Point((int)block.vector.X, (int)block.vector.Y), new Point(50, 50)), Color.White);
                }
            }

            // Draw Eric and the floaters

            _spriteBatch.Draw(ericTexture, eric.rectangle, Color.White);

            _spriteBatch.DrawString(mainFont, Score.scoreText, new Vector2(330, 5), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Start()
        {
            // Runs after loading the game window

            eric = new(new Vector2(600, 530));

            // Go through boardLayout, and create blocks matching to the numbers

            for (int index = 0; index < 165; index++)
            {
                gameBoard[index] = new Block(VectorMath.CalculateActualVector(index), BlockHelper.ConvertToBlockType(boardLayout[index]));
            }
        }
    }
}