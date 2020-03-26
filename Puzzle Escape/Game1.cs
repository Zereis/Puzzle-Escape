using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Puzzle_Escape
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameManager gameManager;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 800;
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameManager = new GameManager(Window, Content);
            gameManager.LoadContent(Content);
        }
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            switch (gameManager.currentGameState)
            {
                case GameState.Mainmenu:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        gameManager.currentGameState = GameState.Play;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        gameManager.currentGameState = GameState.Gameover;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        gameManager.currentGameState = GameState.Win;
                    }
                    if (gameManager.mouseState.LeftButton == ButtonState.Pressed && gameManager.oldMouseState.LeftButton == ButtonState.Released)
                    {
                        if (gameManager.quitChoice.Contains(gameManager.mousePos))
                        {
                            Exit();
                        }
                    }
                    break;
                case GameState.Play:
                    break;
                case GameState.Gameover:
                    break;

            }
            gameManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            gameManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
