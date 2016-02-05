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
    class YesButton
    {
        //properties
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        Color ButtonColorOverlay { get; set; }
        public bool yesPressed;
        //constructor(s)
        public YesButton(Texture2D texture, Vector2 position, Color btnColorOverlay)
        {
            this.Position = position;
            this.Texture = texture;
            this.ButtonColorOverlay = btnColorOverlay;
        }

        /// <summary>
        /// Changes the color for the buttons when your mouse is not over them
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (Mouse.GetState().X > Position.X && Mouse.GetState().X < (Position.X + Texture.Width))
            {
                if (Mouse.GetState().Y > Position.Y && Mouse.GetState().Y < (Position.Y + Texture.Height))
                {
                    ButtonColorOverlay = Color.Blue;
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        yesPressed = true;
                    }
                    else
                    {
                        yesPressed = false;
                    }
                }
            }
            else
            {
                ButtonColorOverlay = Color.White;
            }
        }
        /// <summary>
        /// draws out the buttons
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, ButtonColorOverlay);
        }
    }
}
