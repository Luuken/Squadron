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
        public int eventNumber { get; set; }
        Random rnd = new Random();

        List<string> alertList = new List<string>();
        
        int temp = 0;
        string alertTemp = "";
        bool writeEvent = false;
        bool startTimer = false;
        int timer = 0;
        

        //pilot Errors
        private string pErMessage1 = "The steering wheel is an oval shape, fix it for increased piloting";
        private string pErMessage2 = "The front window has a crack";

        //radar Errors
        private string rErMessage3 = "The radar only shows nearby plant life, fix bugs";
        private string rErMessage4 = "The radar got jamed and now it smells of rasberry!";

        //infermary errors
        private string iErMessage5 = "The bandaids are plugging the sink.";
        private string iErMessage9 = "There is a spider problem in the infermary.";

        //engine errors
        private string eErMessage6 = "Someone left a blueberry pie on the super engine, repairs needed.";
        private string eErMessage7 = "The engine AI got really sad, someone needs to go comfort it.";
        private string eErMessage8 = "Someone mistook the nuts in nuts and bolt for actual nuts.";

        //messages
        private string SMessage = "Select your pilot for the day";
        private string SMessage2 = "Select radar technichan for the day";
        private string SMessage3 = "Someone needs to make food for the week";

        public string DrawText(SpriteBatch spriteBatch, SpriteFont sFont, Vector2 position)
        {
            int randomRoomNumber = rnd.Next(1, 5);
            //pilot errors
            if (randomRoomNumber == 1)
            {
                randomRoomNumber = rnd.Next(1,3);
                eventNumber = 1;
                if (randomRoomNumber == 1)
                {
                    return pErMessage1;
                    
                }
                else if (randomRoomNumber == 2)
                {
                    return pErMessage2;
                }
            }
            //radar errors
            else if (randomRoomNumber == 2)
            {
                eventNumber = 2;
                randomRoomNumber = rnd.Next(1, 3);
                if (randomRoomNumber == 1)
                {
                    return rErMessage4;
                }
                else if (randomRoomNumber == 2)
                {
                    return rErMessage3;
                }
            }
            //infermary errors
            else if (randomRoomNumber == 3)
            {
                eventNumber = 3;
                randomRoomNumber = rnd.Next(1, 3);
                if (randomRoomNumber == 1)
                {
                    return iErMessage5;
                }
                if (randomRoomNumber == 2)
                {
                    return iErMessage9;
                }
                
            }
            //engine Errors
            else if (randomRoomNumber == 4)
            {
                eventNumber = 4;
                randomRoomNumber = rnd.Next(1, 4);
                if (randomRoomNumber == 1)
                {

                    return eErMessage8;
                }
                else if (randomRoomNumber == 2)
                {


                    return eErMessage7;
                }
                else if (randomRoomNumber == 3)
                {

                    return eErMessage6;
                }
            }
            return "WOW DUDE EMPTY STRING MUCH????";
        }

        public void Update(SpriteBatch s, SpriteFont f, Vector2 position)
        {
            temp = rnd.Next(1, 500);
            if (temp == 2)
            {
                //binds random message too a string that is then put in a list
                alertTemp = this.DrawText(s, f, position);
                int tempD;
                if (this.eventNumber == 1)
                {
                    tempD = rnd.Next(60, 190);
                    alertList.Add(alertTemp);
                    startTimer = true;
                    timer = 0;
                    //alertListv2.Add(new PilotEvent((double)tempD, "Pilot event", clock, alertTemp));
                }
                else if (this.eventNumber == 2)
                {
                    tempD = rnd.Next(20, 230);
                    alertList.Add(alertTemp);
                    startTimer = true;
                    timer = 0;
                    //alertListv2.Add(new RadarEvent((double)tempD, "Radar event", clock, alertTemp));
                }
                else if (this.eventNumber == 3)
                {
                    tempD = rnd.Next(90, 110);
                    alertList.Add(alertTemp);
                    startTimer = true;
                    timer = 0;
                    //alertListv2.Add(new InfermaryEvent((double)tempD, "Infermary event", clock, alertTemp));
                }
                else if (this.eventNumber == 4)
                {
                    tempD = rnd.Next(50, 200);
                    alertList.Add(alertTemp);
                    startTimer = true;
                    timer = 0;
                    //alertListv2.Add(new EngineEvent((double)tempD, "Engine event", clock, alertTemp));
                }

                //we should create events based on what string it is + random numbers for duration and such
            }
            if (startTimer == true)
            {
                timer++;
            }

            if (timer == 121)
            {
                timer = 0;
                writeEvent = false;
                startTimer = false;
            }
        }

        public void Draw(SpriteBatch s, SpriteFont f, Texture2D square, Vector2 V2, SpriteFont fs)
        {
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.G))
            {
                s.Draw(square, V2, Color.White);
                s.DrawString(f, "List of problems", new Vector2(365, 20), Color.White);
                for (int i = 0; i < alertList.Count; i++)
                {
                    s.DrawString(fs, alertList[i], new Vector2(400, 50 + (i * 20)), Color.White);

                }
            }
            //early draft, draws the message byt not for as long as i would like nor can you use this for anything
            if (timer > 0)
            {
                writeEvent = true;
                //spriteBatch.DrawString(testFont, alertTemp, new Vector2(75, 800), Color.Red);
            }
            if (writeEvent == true && timer < 120)
            {
                s.DrawString(f, alertTemp, new Vector2(75, 800), Color.Red);
            }
        }
        public void SchedueldAlertMessage(DateTime clock)
        {
            if (clock.Millisecond <= 30 && clock.Second == 0 && clock.Minute == 0 && clock.Hour == 0)
            {
                alertList.Add(SMessage);
                alertList.Add(SMessage2);
            }
            if (clock.DayOfWeek == DayOfWeek.Monday && clock.Millisecond <= 30 && clock.Second == 0 && clock.Minute == 0 && clock.Hour == 0)
            {
                alertList.Add(SMessage3);
            }
        }
    }
}
