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
        Upgrade,
        Heal,
        Default
    }


    class Button
    {
        //Properties
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Color ButtonColorOverlay { get; set; }
        public ButtonName BName { get; set; }
        public bool Pressed { get; set; }

        //Variables
        bool hasBeenPressed = false;
        private int clickedDelay = 10; //onödig variabel?

        //Constructor(s)
        public Button(Texture2D texture, Vector2 position, Color btnColorOverlay, ButtonName bName)
        {
            this.Texture = texture;
            this.Position = position;
            this.ButtonColorOverlay = btnColorOverlay;
            this.BName = bName;
        }

        //Method(s)
        public void Update(GameTime gameTime)
        {
            if (Mouse.GetState().X > Position.X && Mouse.GetState().X < (Position.X + Texture.Width))
            {
                if (Mouse.GetState().Y > Position.Y && Mouse.GetState().Y < (Position.Y + Texture.Height))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonColorOverlay = Color.CornflowerBlue;
                        hasBeenPressed = true;
                    }
                    if (Mouse.GetState().LeftButton == ButtonState.Released && hasBeenPressed == true)
                    {
                        Pressed = true;
                        ButtonColorOverlay = Color.White;
                        hasBeenPressed = false;
                    }
                    else
                    {
                        Pressed = false;
                    }
                }
            }




            /*if (ButtonColorOverlay == Color.CornflowerBlue)
            {
                clickedDelay--;
                if (clickedDelay <= 0)
                {
                    ButtonColorOverlay = Color.White;
                    clickedDelay = 10;
                }
            }  */   
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, ButtonColorOverlay);
        }
    }
}
