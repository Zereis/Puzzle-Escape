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
    class Level
    {
        public static Tile[,] tiles;
        Ball ball;
        List<string> strings = new List<string>();
        public Level(string mapOne)
        {
            CreateLevelOne(mapOne);
        }
        private void CreateLevelOne(string mapOne)
        {

            StreamReader sr = new StreamReader("map.txt");

            while (!sr.EndOfStream)
            {

                strings.Add(sr.ReadLine());

            }

            sr.Close();

            tiles = new Tile[strings[0].Length, strings.Count];

            for (int i = 0; i < tiles.GetLength(0); i++)
            {

                for (int j = 0; j < tiles.GetLength(1); j++)
                {

                    if (strings[j][i] == 'w')
                    {

                        tiles[i, j] = new Tile(TextureManager.wallTex, new Vector2(TextureManager.wallTex.Width * i, TextureManager.wallTex.Height * j), true);

                    }

                    else if (strings[j][i] == '-')
                    {

                        tiles[i, j] = new Tile(TextureManager.floorTex, new Vector2(TextureManager.floorTex.Width * i, TextureManager.floorTex.Height * j), false);

                    }

                    else if (strings[j][i] == 'b')
                    {

                        tiles[i, j] = new Tile(TextureManager.floorTex, new

                        Vector2(TextureManager.floorTex.Width * i,

                        TextureManager.floorTex.Height * j), false);

                        ball = new Ball(TextureManager.ballTex, new Vector2(TextureManager.floorTex.Width * i, TextureManager.floorTex.Height * j));

                    }

                }
            }
        }
        public void Update(GameTime gameTime)
        {
            ball.Update(gameTime);
        }
        public void Draw(SpriteBatch sp)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {

                for (int j = 0; j < tiles.GetLength(1); j++)
                {

                    if (strings[j][i] == 'w' || strings[j][i] == '-' || strings[j][i] == 'b')
                    {

                        tiles[i, j].Draw(sp);

                    }

                }
            }
            ball.Draw(sp);
        }
    }
}
