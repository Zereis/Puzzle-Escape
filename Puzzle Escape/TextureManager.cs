using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Puzzle_Escape
{
    class TextureManager
    {
        public static Texture2D ballTex, wallTex, floorTex, cloudTex, groundTex, emptyTex, empty2Tex;
        public TextureManager(ContentManager content)
        {
            groundTex = content.Load<Texture2D>("Ground");
            cloudTex = content.Load<Texture2D>("Cloud");
            emptyTex = content.Load<Texture2D>("emptyBox");
            empty2Tex = content.Load<Texture2D>("emptyBox2");
            ballTex = content.Load<Texture2D>("ball");
            wallTex = content.Load<Texture2D>("walltile");
            floorTex = content.Load<Texture2D>("floortile");
        }
    }
}
