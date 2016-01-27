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
        protected float Timespan { get; set; }
        protected string EventName { get; set; }

        //booleans
        protected bool eventFinished = false;

        //constructor(s)
        protected Event(float timespan, string eventName)
        {
            this.Timespan = timespan;
            this.EventName = eventName;
        }
        //gif, hur säger man det?
        //method(s)
        protected virtual void Update()
        {
            if (Timespan == 0)
            {
                eventFinished = true;
            }
        }
    }
}
