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
    class PilotEvent : Event
    {
        //constructor(s)
        public PilotEvent(double timespan, string eventName, DateTime currentTime, string startText, Mechanic chara)
            : base(timespan, eventName, currentTime, startText, chara)
        {
            
        }
        //methods
        public override void Draw(SpriteBatch spriteB, SpriteFont Font)
        {
            base.Draw(spriteB, Font);
        }

        public override void Update()
        {
            base.Update();
            for (int i = 0; i < ListOfEvents.StatListEvents.Count; i++)
            {
                if (ListOfEvents.StatListEvents[i].eventFinished == true)
                {
                    StaticGameHelper.pilotingErrorOffsetValue -= 0.087f;
                    ListOfEvents.StatListEvents.RemoveAt(i);
                }
            }
        }

        public void MoveTooPosition()
        {
            //moves too corect position(x,y) in the hub room at the pilot seat
        }
    }
}
