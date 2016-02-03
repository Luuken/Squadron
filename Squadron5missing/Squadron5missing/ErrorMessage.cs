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
    class ErrorMessage
    {
        public SpriteBatch SpriteBatch{ get; set; }
        public SpriteFont SFont { get; set; }
        public Vector2 position { get; set; }
        public string EventAlert { get; set; }

        Random rnd = new Random();
        

        //pilot Errors
        private string pErMessage1 = "The steering wheel is an oval shape, fix it for increased piloting";
        private string pErMessage2 = "The ship needs a pilot for this day, select one!";

        //radar Errors
        private string rErMessage3 = "The radar only shows nearby plant life, calibrate the (differtius thinius radarating) capacitor 2000";
        private string rErMessage4 = "The ship needs a radar technichan to observe it, select one!";

        //infermary errors
        private string iErMessage5 = "The bandaids are plugging the sink and none of the blood is not pouring away, fix it!";

        //engine errors
        private string eErMessage6 = "Someone left a blueberry pie on the super engine, repairs needed";
        private string eErMessage7 = "The engine AI got really sad when it read it's own reviews online, someone needs to go comfort it";
        private string eErMessage8 = "Someone mistook the nuts in nuts and bolt for actual nuts, this made the whole keeping the engine together sort of hard";

        public void DrawText(SpriteBatch spriteBatch, SpriteFont sFont, Vector2 position)
        {
            int randomRoomNumber = rnd.Next(1, 4);
            //pilot errors
            if (randomRoomNumber == 1)
            {
                randomRoomNumber = rnd.Next(1,2);
                if (randomRoomNumber == 1)
                {
                    EventAlert = pErMessage1;
                }
                if (randomRoomNumber == 2)
                {
                    EventAlert = pErMessage2;
                }
            }
            //radar errors
            else if (randomRoomNumber == 1)
            {
                randomRoomNumber = rnd.Next(1, 2);
                if (randomRoomNumber == 3)
                {
                    EventAlert = rErMessage4;
                }
                if (randomRoomNumber == 2)
                {
                    EventAlert = rErMessage3;
                }
            }
            //infermary errors
            else if (randomRoomNumber == 3)
            {
                EventAlert = iErMessage5;
            }
            //engine Errors
            else if (randomRoomNumber == 4)
            {
                randomRoomNumber = rnd.Next(1, 3);
                if (randomRoomNumber == 1)
                {
                    EventAlert = eErMessage8;
                }
                if (randomRoomNumber == 2)
                {
                    EventAlert = eErMessage7;
                }
                if (randomRoomNumber == 3)
                {
                    EventAlert = eErMessage6;
                }
            }
        }
    }
}
