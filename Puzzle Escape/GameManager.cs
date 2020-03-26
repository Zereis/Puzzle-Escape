using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace Puzzle_Escape
{
    public enum GameState
    {
        Mainmenu,
        Play,
        Gameover,
        Win,
    }
    public enum LevelGameState
    {
        LevelOne,
        LevelTwo,
        LevelThree,
        LevelFour
    }
    class GameManager
    {
        public GameState currentGameState = GameState.Mainmenu;
        LevelGameState currentLevel;
        Background background;
        GameWindow window;
        bool nextChoice = false;
        public Rectangle quitChoice, playChoice, returnChoice;
        Rectangle levelOne, levelTwo, levelThree, levelFour;
        public MouseState oldMouseState, mouseState;
        public Point mousePos;
        SpriteFont font;
        Level level1, level2, level3, level4;
        public GameManager(GameWindow window, ContentManager Content)
        {
            new TextureManager(Content);
            this.window = window;
            setLevel("map.text");
        }
        public void setLevel(string mapOne)
        {
            level1 = new Level(mapOne);

        }
        public void LoadContent(ContentManager Content)
        {
            new TextureManager(Content);
            background = new Background(Content, window);
            font = Content.Load<SpriteFont>("font");
        }


        public void Update(GameTime gameTime)
        {
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();
            mousePos = new Point(mouseState.X, mouseState.Y);
            switch (currentGameState)
            {
                case GameState.Mainmenu:
                    background.Update();
                    if (nextChoice == false)
                    {
                        playChoice = new Rectangle((int)530, (int)350, TextureManager.emptyTex.Width, TextureManager.emptyTex.Height);
                        quitChoice = new Rectangle((int)530, (int)450, TextureManager.emptyTex.Width, TextureManager.emptyTex.Height);
                        if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                        {
                            if (playChoice.Contains(mousePos))
                            {
                                nextChoice = true;
                            }
                        }
                    }
                    else if (nextChoice == true)
                    {
                        returnChoice = new Rectangle((int)530, (int)550, TextureManager.empty2Tex.Width, TextureManager.empty2Tex.Height);
                        levelOne = new Rectangle((int)530, (int)350, TextureManager.empty2Tex.Width, TextureManager.empty2Tex.Height);
                        levelTwo = new Rectangle((int)530, (int)400, TextureManager.empty2Tex.Width, TextureManager.empty2Tex.Height);
                        levelThree = new Rectangle((int)530, (int)450, TextureManager.empty2Tex.Width, TextureManager.empty2Tex.Height);
                        levelFour = new Rectangle((int)530, (int)500, TextureManager.empty2Tex.Width, TextureManager.empty2Tex.Height);
                        if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                        {
                            if (returnChoice.Contains(mousePos))
                            {
                                nextChoice = false;
                            }
                            if (levelOne.Contains(mousePos))
                            {
                                currentLevel = LevelGameState.LevelOne;
                                currentGameState = GameState.Play;
                            }
                            if (levelTwo.Contains(mousePos))
                            {
                                currentLevel = LevelGameState.LevelTwo;
                                currentGameState = GameState.Play;
                            }
                            if (levelThree.Contains(mousePos))
                            {
                                currentLevel = LevelGameState.LevelThree;
                                currentGameState = GameState.Play;
                            }
                            if (levelFour.Contains(mousePos))
                            {
                                currentLevel = LevelGameState.LevelFour;
                                currentGameState = GameState.Play;
                            }
                        }
                    }
                    break;
                case GameState.Play:
                    switch (currentLevel)
                    {
                        case LevelGameState.LevelOne:
                            level1.Update(gameTime);
                            break;
                        case LevelGameState.LevelTwo:
                            break;
                        case LevelGameState.LevelThree:
                            break;
                        case LevelGameState.LevelFour:
                            break;
                    }
                    break;
                case GameState.Gameover:
                    break;
                case GameState.Win:
                    break;
            }
        }
        public void Draw(SpriteBatch sb)
        {
            switch (currentGameState)
            {
                case GameState.Mainmenu:
                    background.Draw(sb);
                    if (nextChoice == false)
                    {
                        sb.DrawString(font, "WELCOME TO Puzzle Escape", new Vector2(400, 250), Color.Black);
                        sb.Draw(TextureManager.emptyTex, new Vector2(530, 350), Color.White);
                        sb.DrawString(font, "Play", new Vector2(530, 350), Color.Black);
                        sb.Draw(TextureManager.emptyTex, new Vector2(530, 450), Color.White);
                        sb.DrawString(font, "Quit", new Vector2(530, 450), Color.Black);
                    }
                    if (nextChoice == true)
                    {
                        sb.DrawString(font, "Choice Your Level Stage", new Vector2(450, 250), Color.Black);
                        sb.Draw(TextureManager.empty2Tex, new Vector2(530, 350), Color.White);
                        sb.DrawString(font, "Level 1", new Vector2(530, 350), Color.Black);
                        sb.Draw(TextureManager.empty2Tex, new Vector2(530, 400), Color.White);
                        sb.DrawString(font, "Level 2", new Vector2(530, 400), Color.Black);
                        sb.Draw(TextureManager.empty2Tex, new Vector2(530, 450), Color.White);
                        sb.DrawString(font, "Level 3", new Vector2(530, 450), Color.Black);
                        sb.Draw(TextureManager.empty2Tex, new Vector2(530, 500), Color.White);
                        sb.DrawString(font, "Level 4", new Vector2(530, 500), Color.Black);
                        sb.Draw(TextureManager.empty2Tex, new Vector2(530, 550), Color.White);
                        sb.DrawString(font, "Return", new Vector2(530, 550), Color.Black);
                    }
                    break;
                case GameState.Play:
                    switch (currentLevel)
                    {
                        case LevelGameState.LevelOne:
                            level1.Draw(sb);
                            break;
                        case LevelGameState.LevelTwo:
                            break;
                        case LevelGameState.LevelThree:
                            break;
                        case LevelGameState.LevelFour:
                            break;
                    }
                    break;
                case GameState.Gameover:
                    break;
                case GameState.Win:
                    break;
            }
        }
    }
}

