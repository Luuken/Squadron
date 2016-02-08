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
    class BackScroll
    {
        public Texture2D TextureA { get; set; }
        public Texture2D TextureB { get; set; }
        public float Speed { get; set; }

        private Vector2 positionA = new Vector2(0, 0);
        private Vector2 positionB = new Vector2(1600, 0);


        public BackScroll(Texture2D textureA, Texture2D textureB, float speed)
        {
            this.TextureA = textureA;
            this.TextureB = textureB;
            this.Speed = speed;
        }

        public void Scroll(GraphicsDevice graphicsDevice)
        {
            positionB.X += Speed;
            positionA.X += Speed;


            if (positionA.X > graphicsDevice.Viewport.Width)
            {
                positionA.X -= 1600 * 2;
                positionA.X += Speed;
            }
            if (positionB.X > graphicsDevice.Viewport.Width)
            {
                positionB.X -= 1600 * 2;
                positionB.X += Speed;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureA, positionA, Color.White);
            spriteBatch.Draw(TextureB, positionB, Color.White);
        }
    }
}
