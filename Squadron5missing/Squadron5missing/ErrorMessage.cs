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
using System.Diagnostics;

namespace Squadron5missing
{
    class ErrorMessage
    {
        //properties
        public SpriteBatch SpriteBatch{ get; set; }
        public SpriteFont SFont { get; set; }
        public Vector2 position { get; set; }
        public string EventAlert { get; set; }
        public int eventNumber { get; set; }
        public Mechanic Mech1 { get; set; }
        public Mechanic Mech2 { get; set; }
        public Mechanic Mech3 { get; set; }
        public Resources Resoure { get; set; }
        //variables for this class only
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

        public ErrorMessage(Mechanic m, Mechanic m2, Mechanic m3, Resources resoure)
        {
            this.Mech1 = m;
            this.Mech2 = m2;
            this.Mech3 = m3;
            this.Resoure = resoure;
        }

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
            return "";
        }
        /// <summary>
        /// Updates the ErrorMessages this also sends Yes and No buttons
        /// to ListOfYNButtons lists
        /// </summary>
        /// <param name="s"></param>
        /// <param name="f"></param>
        /// <param name="position"></param>
        /// <param name="buttonTexture"></param>
        /// <param name="buttonTexture2"></param>
        /// <param name="position2"></param>
        public void Update(SpriteBatch s, SpriteFont f, Vector2 position, Texture2D buttonTexture, Texture2D buttonTexture2, Vector2 position2)
        {
            
            temp = rnd.Next(1, 500);
            if (temp == 2)
            {
                //binds random message too a string that is then put in a list
                alertTemp = this.DrawText(s, f, position);
                int tempD;
                if (this.eventNumber == 1)
                {
                    StaticGameHelper.pilotingErrorOffsetValue += 0.087f;
                    tempD = rnd.Next(60, 190);
                    alertList.Add(alertTemp);
                    //this adds one button to each no and yes list button in the ListOfYNButtons.cs lists
                    ListOfYNButtons.ButtonList.Add(new YesButton(EventType.PilotEvent, buttonTexture, position2, Color.CadetBlue));
                    ListOfYNButtons.ButtonList2.Add(new NoButton(buttonTexture2, position, Color.CornflowerBlue));
                    startTimer = true;
                    timer = 0;
                }
                else if (this.eventNumber == 2)
                {

                    tempD = rnd.Next(20, 230);
                    alertList.Add(alertTemp);
                    StaticGameHelper.scrapFindingChance -= 35;
                    //this adds one button to each no and yes list button in the ListOfYNButtons.cs lists
                    ListOfYNButtons.ButtonList.Add(new YesButton(EventType.RadarEvent, buttonTexture, position2, Color.CadetBlue));
                    ListOfYNButtons.ButtonList2.Add(new NoButton(buttonTexture2, position2, Color.CornflowerBlue));
                    startTimer = true;
                    timer = 0;
                }
                else if (this.eventNumber == 3)
                {
                    StaticGameHelper.healthTimeOffsetValue -= 0.05f;
                    tempD = rnd.Next(90, 110);
                    alertList.Add(alertTemp);
                    //this adds one button to each no and yes list button in the ListOfYNButtons.cs lists
                    ListOfYNButtons.ButtonList.Add(new YesButton(EventType.InfermaryEvent, buttonTexture, position2, Color.CadetBlue));
                    ListOfYNButtons.ButtonList2.Add(new NoButton(buttonTexture2, position2, Color.CornflowerBlue));

                    startTimer = true;
                    timer = 0;
                }
                else if (this.eventNumber == 4)
                {
                    Resoure.Hull -= 10;
                    tempD = rnd.Next(50, 200);
                    alertList.Add(alertTemp);
                    //this adds one button to each no and yes list button in the ListOfYNButtons.cs lists
                    ListOfYNButtons.ButtonList.Add(new YesButton(EventType.EngineEvent, buttonTexture, position2, Color.CadetBlue));
                    ListOfYNButtons.ButtonList2.Add(new NoButton(buttonTexture2, position2, Color.CornflowerBlue));
                    startTimer = true;
                    timer = 0;
                }

            }
            //timer for how long the alerts are supposed to be drawn on screen
            if (startTimer == true)
            {
                timer++;
            }

            if (timer == 230)
            {
                timer = 0;
                writeEvent = false;
                startTimer = false;
            }
        }

        public void Draw(SpriteBatch s, SpriteFont f, Texture2D square, Vector2 V2, SpriteFont fs, DateTime clock)
        {
            //change this to the buttons on the character for the finished (game)mechanic
            if (Mech1.resolvePressed == true)
            {
                //adds a menu window behind the list of problems
                //also writes it a title
                s.Draw(square, V2, Color.White);
                s.DrawString(f, "List of problems", new Vector2(365, 20), Color.White);
                
                for (int i = 0; i < alertList.Count; i++)
                {
                    s.DrawString(fs, alertList[i], new Vector2(400, 50 + (i * 20)), Color.White);
                    //sets the position of yes and no buttons
                    //they are then drawn out in the draw function of the individual yes and no button classes
                    ListOfYNButtons.ButtonList[i].Position = new Vector2(358, 50 + (i * 20));
                    ListOfYNButtons.ButtonList2[i].Position = new Vector2(378, 50 + (i * 20));

                    
                    if (ListOfYNButtons.ButtonList[i].yesPressed == true)
                    {

                        if (ListOfYNButtons.ButtonList[i].EventType == EventType.PilotEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new PilotEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech1));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.RadarEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new RadarEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech1));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.InfermaryEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new InfermaryEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech1));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.EngineEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new RadarEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech1));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.PilotingEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new SchedueldEvent((double)86400, "Error", clock, "", Mech1));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.ScanningEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new Event((double)86400, "Error", clock, "", Mech1));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.CookingEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new Event((double)86400, "Error", clock, "", Mech1));
                        }

                        ListOfYNButtons.ButtonList.RemoveAt(i);
                        ListOfYNButtons.ButtonList2.RemoveAt(i);
                        alertList.RemoveAt(i);
                        Mech1.resolvePressed = false;
                        Mech1.yesIsSelected = true;
                    }
                    else if (ListOfYNButtons.ButtonList2[i].noPressed == true)
                    {
                        ListOfYNButtons.ButtonList.RemoveAt(i);
                        ListOfYNButtons.ButtonList2.RemoveAt(i);
                        alertList.RemoveAt(i);
                        Mech1.resolvePressed = false;

                    } 
                    
                }
            }
            else if (Mech2.resolvePressed == true)
            {
                //adds a menu window behind the list of problems
                //also writes it a title
                s.Draw(square, V2, Color.White);
                s.DrawString(f, "List of problems", new Vector2(365, 20), Color.White);

                for (int i = 0; i < alertList.Count; i++)
                {
                    s.DrawString(fs, alertList[i], new Vector2(400, 50 + (i * 20)), Color.White);
                    //sets the position of yes and no buttons
                    //they are then drawn out in the draw function of the individual yes and no button classes
                    ListOfYNButtons.ButtonList[i].Position = new Vector2(358, 50 + (i * 20));
                    ListOfYNButtons.ButtonList2[i].Position = new Vector2(378, 50 + (i * 20));

                    if (ListOfYNButtons.ButtonList[i].yesPressed == true)
                    {
                        if (ListOfYNButtons.ButtonList[i].EventType == EventType.PilotEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new PilotEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech2));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.RadarEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new RadarEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech2));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.InfermaryEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new InfermaryEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech2));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.EngineEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new RadarEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech2));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.PilotingEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new SchedueldEvent((double)86400, "Error", clock, "", Mech2));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.ScanningEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new Event((double)86400, "Error", clock, "", Mech2));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.CookingEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new Event((double)86400, "Error", clock, "", Mech2));
                        }
                        ListOfYNButtons.ButtonList.RemoveAt(i);
                        ListOfYNButtons.ButtonList2.RemoveAt(i);
                        alertList.RemoveAt(i);
                        Mech2.resolvePressed = false;
                        Mech2.yesIsSelected = true;
                    }
                    else if (ListOfYNButtons.ButtonList2[i].noPressed == true)
                    {
                        ListOfYNButtons.ButtonList.RemoveAt(i);
                        ListOfYNButtons.ButtonList2.RemoveAt(i);
                        alertList.RemoveAt(i);
                        Mech2.resolvePressed = false;

                    }

                }
            }
            else if (Mech3.resolvePressed == true)
            {
                //adds a menu window behind the list of problems
                //also writes it a title
                s.Draw(square, V2, Color.White);
                s.DrawString(f, "List of problems", new Vector2(365, 20), Color.White);

                for (int i = 0; i < alertList.Count; i++)
                {
                    s.DrawString(fs, alertList[i], new Vector2(400, 50 + (i * 20)), Color.White);
                    //sets the position of yes and no buttons
                    //they are then drawn out in the draw function of the individual yes and no button classes
                    ListOfYNButtons.ButtonList[i].Position = new Vector2(358, 50 + (i * 20));
                    ListOfYNButtons.ButtonList2[i].Position = new Vector2(378, 50 + (i * 20));

                    if (ListOfYNButtons.ButtonList[i].yesPressed == true)
                    {
                        if(ListOfYNButtons.ButtonList[i].EventType == EventType.PilotEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new PilotEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech3));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.RadarEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new RadarEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech3));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.InfermaryEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new InfermaryEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech3));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.EngineEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new RadarEvent((double)rnd.Next(70, 110), "Error", clock, "", Mech3));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.PilotingEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new SchedueldEvent((double)86400, "Error", clock, "", Mech3));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.ScanningEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new Event((double)86400, "Error", clock, "", Mech3));
                        }
                        else if (ListOfYNButtons.ButtonList[i].EventType == EventType.CookingEvent)
                        {
                            ListOfEvents.StatListEvents.Add(new Event((double)86400, "Error", clock, "", Mech3));
                        }
                        ListOfYNButtons.ButtonList.RemoveAt(i);
                        ListOfYNButtons.ButtonList2.RemoveAt(i);
                        alertList.RemoveAt(i);
                        Mech3.resolvePressed = false;
                        Mech3.yesIsSelected = true;
                    }
                    else if (ListOfYNButtons.ButtonList2[i].noPressed == true)
                    {
                        ListOfYNButtons.ButtonList.RemoveAt(i);
                        ListOfYNButtons.ButtonList2.RemoveAt(i);
                        alertList.RemoveAt(i);
                        Mech3.resolvePressed = false;

                    }

                }
            }
            else
            {
                for (int i = 0; i < alertList.Count; i++)
                {
                    //moves the buttons of screen
                    ListOfYNButtons.ButtonList[i].Position = new Vector2(-20, -20);
                    ListOfYNButtons.ButtonList2[i].Position = new Vector2(-20, -20);
                }
                
            }


            if (timer > 0)
            {
                writeEvent = true;
                //spriteBatch.DrawString(testFont, alertTemp, new Vector2(75, 800), Color.Red);
            }
            if (writeEvent == true && timer < 230)
            {
                s.DrawString(f, alertTemp, new Vector2(450, 630), Color.Red);
            }
        }
        /// <summary>
        /// adds schedueld messages that will 
        /// always apear on scripted times
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="buttonTexture"></param>
        /// <param name="position"></param>
        /// <param name="buttonTexture2"></param>
        public void SchedueldAlertMessage(DateTime clock, Texture2D buttonTexture, Vector2 position, Texture2D buttonTexture2)
        {
            if (clock.Millisecond <= 30 && clock.Second == 0 && clock.Minute == 0 && clock.Hour == 0)
            {
                
                alertList.Add(SMessage);
                //moves it of the screen
                ListOfYNButtons.ButtonList.Add(new YesButton(EventType.PilotingEvent, buttonTexture, new Vector2(-20, -20), Color.CadetBlue));
                ListOfYNButtons.ButtonList2.Add(new NoButton(buttonTexture2, new Vector2(-20, -20), Color.CornflowerBlue));
                
            }
            if (clock.Millisecond <= 30 && clock.Second == 0 && clock.Minute == 0 && clock.Hour == 0)
            {
                
                alertList.Add(SMessage2);
                //moves it of the screen
                ListOfYNButtons.ButtonList.Add(new YesButton(EventType.ScanningEvent, buttonTexture, new Vector2(-20, -20), Color.CadetBlue));
                ListOfYNButtons.ButtonList2.Add(new NoButton(buttonTexture2, new Vector2(-20, -20), Color.CornflowerBlue));
            }
            if (clock.DayOfWeek == DayOfWeek.Monday && clock.Millisecond <= 30 && clock.Second == 0 && clock.Minute == 0 && clock.Hour == 0)
            {
                
                alertList.Add(SMessage3);
                //moves it of the screen
                ListOfYNButtons.ButtonList.Add(new YesButton(EventType.CookingEvent, buttonTexture, new Vector2(-20, -20), Color.CadetBlue));
                ListOfYNButtons.ButtonList2.Add(new NoButton(buttonTexture2, new Vector2(-20, -20), Color.CornflowerBlue));
            }
        }
    }
}
