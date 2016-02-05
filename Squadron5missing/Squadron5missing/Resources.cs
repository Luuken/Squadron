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
        public int Food { get; set; }
        public int ScrapMetal { get; set; }
        public int Oxygen { get; set; }
        public int Fuel { get; set; }

        public Resources(int food, int scrapMetal, int oxygen, int fuel)
        {
            this.Food = food;
            this.ScrapMetal = scrapMetal;
            this.Oxygen = oxygen;
            this.Fuel = fuel;
        }

        public void PrintInfo(SpriteFont sFont, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(sFont, "The ship is currently containing " + Food.ToString() + " units of food", new Vector2(2, 20), Color.White);
            spriteBatch.DrawString(sFont, "The ship is currently containing " + ScrapMetal.ToString() + " pounds of Scrap Metal", new Vector2(2, 40), Color.White);
            spriteBatch.DrawString(sFont, "The ship is currently at" + Oxygen.ToString() + "% oxygen capacity", new Vector2(2, 60), Color.White);
            spriteBatch.DrawString(sFont, "The ship is currently containing " + Fuel.ToString() + " units of fuel", new Vector2(2, 80), Color.White);
        }
    }
}
