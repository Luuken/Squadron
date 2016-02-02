using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Squadron5missing
{
    class PilotEvent : Event
    {
        public PilotEvent(double timespan, string eventName, DateTime currentTime, string startText)
            : base(timespan, eventName, currentTime, startText)
        {
            
        }
    }
}
