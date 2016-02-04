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
        Color ButtonColorOverlay { get; set; }

        public NoButton(Texture2D texture, Vector2 position, Color btnColorOverlay)
        {
            this.Texture = texture;
            this.Position = position;
            this.ButtonColorOverlay = btnColorOverlay;
        }
        public void Update(GameTime gameTime)
        {
            if (Mouse.GetState().X > Position.X && Mouse.GetState().X < (Position.X + Texture.Width))
            {
                if (Mouse.GetState().Y > Position.Y && Mouse.GetState().Y < (Position.Y + Texture.Height))
                {
                    ButtonColorOverlay = Color.Blue;
                    //enter click logic here THIS IS WHERE WE CAN CREATE THE EVENTS MAN!!
                }
            }
            else
            {
                ButtonColorOverlay = Color.White;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, ButtonColorOverlay);
        }

    }
}
