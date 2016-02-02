using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Squadron5missing
{
    class RadarEvent : Event
    {
        public RadarEvent(double timespan, string eventName, DateTime currentTime, string startText)
            : base(timespan, eventName, currentTime, startText)
        {
            
        }
        public void MoveTooPosition()
        {
            //moves too corect position(x,y) in the hub room at the radar
        }
    }
}
