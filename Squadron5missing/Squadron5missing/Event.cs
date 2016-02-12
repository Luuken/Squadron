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
    class Event
    {
        //properties

        public DateTime ETC { get; set; }
        public double Timespan { get; set; }
        public DateTime CurrentTime { get; set; }
        public string EventName { get; set; }
        public string StartText { get; set; }
        public Mechanic Chara { get; set; }
        //booleans
        public bool eventFinished = false;

        //constructor(s)
        public Event(double timespan, string eventName, DateTime currentTime, string startText, Mechanic chara)
        {
            this.Timespan = timespan;
            this.EventName = eventName;
            this.CurrentTime = currentTime;
            this.ETC = CurrentTime.AddSeconds(timespan);
            this.StartText = startText;
            this.Chara = chara;
        }

        //method(s)
        public virtual void Draw(SpriteBatch spriteB,SpriteFont Font) //kanske onödig
        {
            spriteB.DrawString(Font, this.ETC.ToLongTimeString(), new Vector2(3, 62), Color.White);
            spriteB.DrawString(Font, this.CurrentTime.ToLongTimeString(), new Vector2(3, 42), Color.White);
            spriteB.DrawString(Font, this.eventFinished.ToString(), new Vector2(3, 22), Color.White);
        }
        public virtual void DrawText(SpriteBatch spriteBatch, SpriteFont sFont, Vector2 position)
        {

            spriteBatch.DrawString(sFont, StartText, position, Color.White);
        }

        public virtual void Update()
        {
            
            if (ETC.CompareTo(CurrentTime) == -1)
            {
                eventFinished = true;
            }

        }
        
    }
}
