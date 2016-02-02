using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Squadron5missing
{
    class InfermaryEvent : Event
    {
        public InfermaryEvent(double timespan, string eventName, DateTime currentTime, string startText)
            : base(timespan, eventName, currentTime, startText)
        {
            
        }

        public void MoveTooRoom()
        {
            //for-loops too move to the elevators X and Y cordiantes
            //then move move to the correct room
        }
    }
}
