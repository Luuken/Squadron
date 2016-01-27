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
        private float Timespan { get; set; }
        private string EventName { get; set; }

        //booleans
        public bool eventFinished = false;

        //constructor(s)
        protected Event(float timespan, string eventName)
        {
            this.Timespan = timespan;
            this.EventName = eventName;
        }
    }
    class SpecialEvent : Event
    {
        protected Event event1 { get; set; }
        protected SpecialEvent(float timespan, string eventName, Event specialEvent) : base(timespan,eventName)
        {
            event1 = specialEvent;
        }

        protected void RunEvent()
        {
            event1.eventFinished = true;
        }
    }
}
