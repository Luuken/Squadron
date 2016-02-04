using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Squadron5missing
{
    public enum ButtonName
    {
        Resolve,
        Eat,
        Tweak,
        Talk
    }

    class Button
    {
        Texture2D Texture { get; set; }
        Vector2 Position { get; set; }
        Color ButtonColorOverlay { get; set; }
        ButtonName BName { get; set; }

        private int clickedDelay = 60;

        public Button(Texture2D texture, Vector2 position, Color btnColorOverlay, ButtonName bName)
        {
            this.Texture = texture;
            this.Position = position;
            this.ButtonColorOverlay = btnColorOverlay;
            this.BName = bName;
        }

        public void Update(GameTime gameTime)
        {
            if (Mouse.GetState().X > Position.X && Mouse.GetState().X < (Position.X + Texture.Width))
            {
                if (Mouse.GetState().Y > Position.Y && Mouse.GetState().Y < (Position.Y + Texture.Height))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonColorOverlay = Color.CornflowerBlue;
                        if (BName == ButtonName.Eat)
                        {

                        }
                        else if (BName == ButtonName.Resolve)
                        {

                        }
                        else if (BName == ButtonName.Talk)
                        {

                        }
                        else if (BName == ButtonName.Tweak)
                        {

                        }
                    }
                    else
                    {
                        ButtonColorOverlay = Color.White;
                    }
                }
            }

            if (ButtonColorOverlay == Color.CornflowerBlue)
            {
                clickedDelay--;
                if (clickedDelay <= 0)
                {
                    ButtonColorOverlay = Color.White;
                    clickedDelay = 60;
                }
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, ButtonColorOverlay);
        }
    }
}
