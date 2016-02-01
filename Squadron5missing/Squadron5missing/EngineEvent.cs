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
    
    class EngineEvent : Event
    {
        //properties
        protected string StartText { get; set; }

        //constructor(s)
        public EngineEvent(double timespan, string eventName, string startText, DateTime currentTime)
            : base(timespan, eventName, currentTime)
        {
            this.StartText = startText;
        }

        public void DrawText(string textToDraw, SpriteBatch spriteBatch, SpriteFont sFont, Vector2 position)
        {
            spriteBatch.DrawString(sFont, textToDraw, position, Color.White);
        }
    }
}
