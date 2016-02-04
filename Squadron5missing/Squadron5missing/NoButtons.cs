using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Squadron5missing
{
    class NoButton
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }

        public NoButton(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }

    }
}
