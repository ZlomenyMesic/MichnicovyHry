using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Test
{
    public class Game1 : Game
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

        public Texture2D cross;
        public static Texture2D textureWall;
        public static Texture2D textureWeakWall;
        public static Texture2D textureTreasure;
        public static Texture2D textureExitPortal;
        public static Texture2D ericTexture;

        public SpriteFont mainFont;

        public KeyboardState keyboardState;

        Eric eric;


        public Game1()
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

            cross = Content.Load<Texture2D>("cross");
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

            KeyboardExitButton(keyboardState);
            KeyboardMovePlayer(keyboardState);
            KeyboardPlaceBomb(keyboardState);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // Go through every block and draw it

            foreach (Block block in gameBoard)
            {
                if (GetBlockTypeTexture(block.blockType) != null)
                {
                    _spriteBatch.Draw(GetBlockTypeTexture(block.blockType), new Rectangle(new Point((int)block.vector.X, (int)block.vector.Y), new Microsoft.Xna.Framework.Point(50, 50)), Microsoft.Xna.Framework.Color.White);
                }
            }

            // Draw the close button, Eric and floaters

            _spriteBatch.Draw(ericTexture, eric.rectangle, Color.White);
            _spriteBatch.Draw(cross, new Rectangle(new Point(725, 5), new Point(20, 20)), Color.White);

            _spriteBatch.DrawString(mainFont, "SCORE: 0", new Vector2(330, 5), Color.White);
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
                gameBoard[index] = new Block(CalculateActualVector(index), ConvertToBlockType(boardLayout[index]));
            }
        }

        #region KeyBinds

        public void KeyboardMovePlayer(KeyboardState keyboardState)
        {
            // Move the player if the user presses a key

            if (keyboardState.IsKeyDown(Keys.W)) { EricMoveUp(); }
            if (keyboardState.IsKeyDown(Keys.A)) { EricMoveLeft(); }
            if (keyboardState.IsKeyDown(Keys.S)) { EricMoveDown(); }
            if (keyboardState.IsKeyDown(Keys.D)) { EricMoveRight(); }

        }

        public void KeyboardPlaceBomb(KeyboardState keyboardState)
        {
            // Place a bomb if the user pressed key B

            if (keyboardState.IsKeyDown(Keys.B))
            {
                //Bomb.Place();
            }
        }

        public void KeyboardExitButton(KeyboardState keyboardState)
        {
            // Exit the game if the user presses the escape button

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
        }

        #endregion

        #region Moving

        public void EricMoveUp()
        {


        }

        public void EricMoveDown()
        {

        }

        public void EricMoveLeft()
        {

        }

        public void EricMoveRight()
        {

        }

        #endregion

        #region BlockChecking

        public static bool IsFree(Vector2 vector)
        {
            // Check if the block at the given coordinates is empty

            if (boardLayout[CalculateBoardPosition(vector)] == 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsOutOfRange(Vector2 vector)
        {
            // Check if the given coordinates are outside the board

            if (((vector.X / 50) > 15) || ((vector.X / 50) < 1)
                || ((vector.Y / 50) > 11) || ((vector.Y / 50) < 1))
            {
                return true;
            }
            return false;
        }

        public static bool IsBomb(Vector2 vector)
        {
            // Check if the block at the given coordinates is a bomb

            if (boardLayout[CalculateBoardPosition(vector)] == 3)
            {
                return true;
            }
            return false;
        }

        public static bool IsDestructable(Vector2 vector)
        {
            // Check if the block at the given coordinates is a weak brick

            if (boardLayout[CalculateBoardPosition(vector)] == 2)
            {
                return true;
            }
            return false;
        }

        public static bool CanExplode(Vector2 vector)
        {
            // Check if the block at the given coordinates can be exploded

            if (!IsOutOfRange(vector) && (IsFree(vector) || IsDestructable(vector)))
            {
                return true;
            }
            return false;
        }

        public static bool CanBeWalkedThrough(Vector2 vector)
        {
            // Check if the block at the given coordinates isn't a wall

            int num = boardLayout[CalculateBoardPosition(vector)];
            if ((num == 0) || (num == 3) || (num == 4) || (num == 5) || (num == 6))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region VectorMath
        public static int CalculateBoardPosition(Vector2 vector)
        {
            // Convert XY coordinates to a single number

            return (int)((((vector.Y / 50) - 1) * 15) + (vector.X / 50) - 1);
        }

        public static Vector2 CalculateBoardVector(int boardPosition)
        {
            // Convert a single number to XY board relative coordinates

            int x = (boardPosition % 15) + 1;
            int y = (boardPosition + 15 - (boardPosition % 15)) / 15;
            return new Vector2(x, y);
        }

        public static Vector2 CalculateActualVector(int boardPosition)
        {
            // Convert a single number to XY window relative coordinates

            int x = (boardPosition % 15) + 1;
            int y = (boardPosition + 15 - (boardPosition % 15)) / 15;
            return new Vector2((x - 1) * 50, (y - 1) * 50 + 30);
        }
        #endregion

        #region Block

        public static Texture2D GetBlockTypeTexture(BlockType blockType)
        {
            // Return block textures from a BlockType

            switch (blockType)
            {
                case BlockType.Air: return null;
                case BlockType.Wall: return textureWall;
                case BlockType.WeakWall: return textureWeakWall;
                case BlockType.Treasure: return textureTreasure;
                case BlockType.ExitPortal: return textureExitPortal;
                default: return null;
            }
        }

        public BlockType ConvertToBlockType(int number)
        {
            // Convert numbers to a BlockType

            switch (number)
            {
                case 0: return BlockType.Air;
                case 1: return BlockType.Wall;
                case 2: return BlockType.WeakWall;
                case 3: return BlockType.Treasure;
                case 4: return BlockType.ExitPortal;
                default: return BlockType.Air;
            }
        }
    }

    public class Block
    {
        public Vector2 vector;
        public BlockType blockType;

        public Block(Vector2 newVector, BlockType newBlockType)
        {
            // Block constructor, create a new block

            vector = newVector;
            blockType = newBlockType;
        }

        public void ClearBlock()
        {
            // Set the block to air

            Game1.boardLayout[Game1.CalculateBoardPosition(vector)] = 0;
            blockType = BlockType.Air;
        }
    }

    public enum BlockType
    {
        Air,
        Wall,
        WeakWall,
        Treasure,
        ExitPortal
    }
    #endregion

    #region Eric
    public class Eric : Game
    {
        public Vector2 position;
        public Rectangle rectangle;

        public Eric(Vector2 startPos)
        {
            // Eric constructor, create Eric

            position = startPos;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
        }

        public void Move(Vector2 newPos)
        {
            // Move Eric to a new location

            position = newPos;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
        }

        public void Kill()
        {
            // Kill Eric

            Game1.ericTexture.Dispose();
        }
    }
    #endregion
}