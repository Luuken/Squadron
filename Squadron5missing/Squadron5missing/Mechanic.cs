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
    class Mechanic : Character
    {
        //properties
        public string WrenchName { get; set; }

        //boolean(s)

        //contructor(s)
        public Mechanic(Texture2D texture, Vector2 position, RoomE room, string name, int animWidth, int animHeight, int maxFrames, int intel, int perc, int stam, int con, int hand, string wName)
            : base(texture, position, room, name, animWidth, animHeight, maxFrames, intel, perc, stam, con, hand)
        {
            this.WrenchName = wName;
        }

        //method(s)
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
