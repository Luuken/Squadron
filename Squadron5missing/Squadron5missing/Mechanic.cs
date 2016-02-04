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
using System.Diagnostics;

namespace Squadron5missing
{
    class Mechanic : Character
    {
        //properties
        public string WrenchName { get; set; }

        ButtonName selectedOption = ButtonName.Default;
        List<Button> buttonList = new List<Button>();
        
        //boolean(s)
        bool hasCreatedButtons = false;


        //contructor(s)
        public Mechanic(Texture2D texture, Vector2 position, RoomE room, string name, int animWidth, int animHeight, int maxFrames, Button button1, Button button2, Button button3, Button button4, int intel, int perc, int stam, int con, int hand, string wName)
            : base(texture, position, room, name, animWidth, animHeight, maxFrames, button1, button2, button3, button4, intel, perc, stam, con, hand)
        {
            this.WrenchName = wName;
        }

        //method(s)
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (characterSelected == true && hasCreatedButtons == false)
            {
                hasCreatedButtons = true;
                buttonList.Add(CharButton1);
                buttonList.Add(CharButton2);
                buttonList.Add(CharButton3);
                buttonList.Add(CharButton4);
            }

            if (hasCreatedButtons == true)
            {
                foreach (Button b in buttonList)
                {
                    b.Update(gameTime);
                    if(b.Pressed)
                    {
                        selectedOption = b.BName;
                    }
                }
            }

            Debug.WriteLine(selectedOption.ToString());

            if (selectedOption == ButtonName.Resolve)
            {
                Position = new Vector2((Position.X - 1), Position.Y);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (Button b in buttonList)
            {
                b.Draw(spriteBatch);
            }
        }
        public override void DrawText(SpriteBatch spriteBatch, SpriteFont font)
        {
            base.DrawText(spriteBatch, font);
        }
    }
}
