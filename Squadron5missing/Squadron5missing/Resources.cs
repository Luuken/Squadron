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
    class Resources
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }

        public SpriteFont Font { get; set; }
        public SpriteBatch sBatch { get; set; }
        
        public int Food { get; set; }
        public int ScrapMetal { get; set; }
        public int Oxygen { get; set; }
        public int Fuel { get; set; }
        public int Hull { get; set; }

        bool hasBeenPressed = false;

        public Resources(Texture2D texture, Vector2 position, SpriteFont font, SpriteBatch spriteBatch, int food, int scrapMetal, int oxygen, int fuel, int hull)
        {
            this.Texture = texture;
            this.Position = position;
            this.Font = font;
            this.sBatch = spriteBatch;
            this.Food = food;
            this.ScrapMetal = scrapMetal;
            this.Oxygen = oxygen;
            this.Fuel = fuel;
            this.Hull = hull;
        }

        public void MaxAndMinResource()
        {
            if (Food < 0)
            {
                Food = 0;
            }
            if (ScrapMetal < 0)
            {
                ScrapMetal = 0;
            }
            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
            if (Fuel < 0)
            {
                Fuel = 0;
            }
            if (Hull < 0)
            {
                Hull = 0;
            }
            if (Food > 1000)
            {
                Food = 1000;
            }
            if (ScrapMetal > 1000)
            {
                ScrapMetal = 1000;
            }
            if (Oxygen > 100)
            {
                Oxygen = 100;
            }
            if (Fuel > 10000)
            {
                Fuel = 10000;
            }
            if (Hull > 100)
            {
                Hull = 100;
            }

            if (Mouse.GetState().X > Position.X && Mouse.GetState().X < (Position.X + Texture.Width))
            {
                if (Mouse.GetState().Y > Position.Y && Mouse.GetState().Y < (Position.Y + Texture.Height))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        hasBeenPressed = true;
                    }
                    if (Mouse.GetState().LeftButton == ButtonState.Released && hasBeenPressed == true)
                    {
                        hasBeenPressed = false;
                    }
                    else
                    {
                        
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont sFont)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            spriteBatch.DrawString(sFont, "Resources", Position, Color.White);
            if (hasBeenPressed)
            {
                this.PrintInfo(Font, sBatch);
            }
        }

        public void PrintInfo(SpriteFont sFont, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(sFont, "The ship is currently containing " + Food.ToString() + " units of food", new Vector2(2, 120), Color.White);
            spriteBatch.DrawString(sFont, "The ship is currently containing " + ScrapMetal.ToString() + " pounds of Scrap Metal", new Vector2(2, 40), Color.White);
            spriteBatch.DrawString(sFont, "The ship is currently at " + Oxygen.ToString() + "% oxygen capacity", new Vector2(2, 60), Color.White);
            spriteBatch.DrawString(sFont, "The ship is currently containing " + Fuel.ToString() + " units of fuel", new Vector2(2, 80), Color.White);
            spriteBatch.DrawString(sFont, "The ship is currently at " + Hull.ToString() + "% hull integrity", new Vector2(2, 100), Color.White);
        }
    }
}
