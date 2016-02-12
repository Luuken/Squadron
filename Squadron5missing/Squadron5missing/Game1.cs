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
using System.Diagnostics;

namespace Squadron5missing
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BackScroll b;
        
        DateTime clock;
        SpriteFont testFont;
        SpriteFont fontSmall;
        Event e;
        Mechanic mechanic;
        Mechanic mechanic2;
        Mechanic dora;
        Mechanic spencer;
        Mechanic lavender;
        EngineEvent engineEvent;

        Resources resource;

        //Put all foreground objects here
        ForegroundObject elevator;
        ForegroundObject radar;
        ForegroundObject screen;
        ForegroundObject loseScreen;

        Random rand;
        //List<string> alertList = new List<string>();
        List<Event> alertListv2 = new List<Event>();
        List<Button> buttonList;

        Texture2D ProblemMenuBackground;
        Texture2D background;
        Texture2D menu;
        Texture2D spaceBackground;
        Texture2D introScreen;

        Texture2D victoryTexture;
        Vector2 victoryPos;

        Button startButton;
        Button quitButton;
        Button creditsButton;
        Button preStartScreen;

        RoomTab roomTab1;
        RoomTab roomTab2;
        RoomTab roomTab3;
        RoomTab roomTab4;
        RoomTab roomTab5;
        RoomTab roomTab6;

        Texture2D RoomCamera1;
        Texture2D RoomCamera2;
        Texture2D RoomCamera3;
        Texture2D RoomCamera4;
        Texture2D RoomCamera5;
        Texture2D RoomCamera6;
        List<Texture2D> RoomTextures;
        List<RoomTab> RoomTabs;

        //Not in use remove when there is time
        Texture2D repairKnapp;
        Texture2D matKnapp;
        Texture2D sjukvårdsKnapp;
        Rectangle repairKnappRectangle;
        Rectangle matKnappRectangle;
        Rectangle sjukvårdsKnappRectangle;
        
        //in use
        Texture2D yesButton;
        Texture2D noButton;
        Texture2D tab1Texture;
        Texture2D tab2Texture;
        Texture2D tab3Texture;

        List<Character> Characters;

        GameState gameState = GameState.PreStart;

        ErrorMessage p;
        bool gameLost = false;
        public int gameSpeed = 1;
        public double distance = 0;
        int temp;
        int maxEvents;
        int HealthLossTimer;
        int lel = 0;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            clock = new DateTime();

            tab1Texture = Content.Load<Texture2D>("Tab Button Engineroom");
            tab2Texture = Content.Load<Texture2D>("Tab Button Infirmary");
            tab3Texture = Content.Load<Texture2D>("Tab Button Kitchen");

            b = new BackScroll(Content.Load<Texture2D>("space02"), Content.Load<Texture2D>("space03"), .03f);
            background = Content.Load<Texture2D>("background12");
            menu = Content.Load<Texture2D>("menu_layout");
            preStartScreen = new Button(Content.Load<Texture2D>("start00"), new Vector2(0,0), Color.White, ButtonName.Default);
            introScreen = Content.Load<Texture2D>("Intro");

            startButton = new Button(Content.Load<Texture2D>("Start Button"), new Vector2(GraphicsDevice.Viewport.Width - 300, 50), Color.White, ButtonName.Start);
            creditsButton = new Button(Content.Load<Texture2D>("Start Button"), new Vector2(GraphicsDevice.Viewport.Width - 300, 350), Color.White, ButtonName.Credits);
            quitButton = new Button(Content.Load<Texture2D>("Start Button"), new Vector2(GraphicsDevice.Viewport.Width - 300, 650), Color.White, ButtonName.Quit);

            elevator = new ForegroundObject(Content.Load<Texture2D>("elevator_002"), new Vector2(352, 264), 500, 500, 13, 4, 100);
            radar = new ForegroundObject(Content.Load<Texture2D>("radartech01"), new Vector2(1010, 420), 350, 100, 4, 2, 100);
            screen = new ForegroundObject(Content.Load<Texture2D>("screen01"), new Vector2(990, 140), 350, 300, 2, 2, 100);
            loseScreen = new ForegroundObject(Content.Load<Texture2D>("end_screen02"), new Vector2(0, 0), 1600, 900, 2, 2, 100);

            Characters = new List<Character>();

            this.IsMouseVisible = true;

            spaceBackground = Content.Load<Texture2D>("Space BG");
            
            base.Initialize();

            RoomTabs = new List<RoomTab>();
            RoomTextures = new List<Texture2D>();

            resource = new Resources(Content.Load<Texture2D>("resource_button"), new Vector2(2, 18), testFont, spriteBatch, 200, 300, 100, 3000, 100);

            buttonList = new List<Button>();

            victoryTexture = Content.Load<Texture2D>("victory_00");
            victoryPos = new Vector2(-1000, 0);
            
            //Setting graphics settings
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            rand = new Random();
            //Initializing characters
            spencer = new Mechanic(Content.Load<Texture2D>("spencer_idle_04"), new Vector2(1100, 400), RoomE.Bridge, resource, "Spencer Bara", 300, 300, 3, 2, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("spencer_walk_left_00"), 8, 3, Content.Load<Texture2D>("spencer_walk_right_01"), 8, 3, Content.Load<Texture2D>("spencer_walk_up_04"), 8, 3, Content.Load<Texture2D>("spencer_walk_down_05"), 8, 3,
                    5, 5, 5, 5, 5, 100, "", Content.Load<Texture2D>("Portrait Spencer"), Content.Load<Texture2D>("Spencer Dead"), Content.Load<Texture2D>("Spencer dead still"));

            spencer.ID = 4;

            lavender = new Mechanic(Content.Load<Texture2D>("Lavender_Idle"), new Vector2(500, 400), RoomE.Bridge, resource, "Lavender Flowers", 174, 300, 10, 5, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("lavender walk left"), 8, 5, Content.Load<Texture2D>("lavender walk right"), 8, 5, Content.Load<Texture2D>("Lavender Walk Back"), 8, 5, Content.Load<Texture2D>("Lavender Walk Front"), 8, 5,
                    5, 5, 5, 5, 5, 100, "", Content.Load<Texture2D>("Portrait Lavender"), Content.Load<Texture2D>("Lavender Dead"), Content.Load<Texture2D>("Lavender dead still"));
            lavender.ID = 5;

            dora = new Mechanic(Content.Load<Texture2D>("Dora Hairflip"), new Vector2(700, 400), RoomE.Bridge, resource, "Dora \"the Explorah\" Dandy", 174, 300, 13, 5, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("Dora Walk Left"), 8, 5, Content.Load<Texture2D>("Dora Walk Right"), 8, 5, Content.Load<Texture2D>("Dora Walk Back"), 8, 5, Content.Load<Texture2D>("Dora Walk Front"), 8, 5,
                    5, 5, 5, 5, 5, 100, "", Content.Load<Texture2D>("Portrait Dora"), Content.Load<Texture2D>("Dora Dead"), Content.Load<Texture2D>("Dora dead still"));

            dora.ID = 3;

            mechanic = new Mechanic(Content.Load<Texture2D>("Kitty Breath Blink"), new Vector2(1000, 450), RoomE.Bridge, resource, "Kitty Kat", 174, 300, 9, 5, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("Kitty Walk Left"), 8, 5, Content.Load<Texture2D>("Kitty Walk Right"), 8, 5, Content.Load<Texture2D>("Kitty Walk Back"), 9, 5, Content.Load<Texture2D>("Kitty Walk Front"),
                    9, 5, 5, 5, 5, 8, 5, 100, "Olaf", Content.Load<Texture2D>("Portrait Kitty"), Content.Load<Texture2D>("Kitty Dead"), Content.Load<Texture2D>("Kitty dead still"));

            mechanic.ID = 1;

            mechanic2 = new Mechanic(Content.Load<Texture2D>("idle_pose02"), new Vector2(300, 450), RoomE.Bridge, resource, "Blondie Bubs", 300, 300, 8, 3, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("walk_right_03"), 8, 3, Content.Load<Texture2D>("walk_right_03"), 8, 3, Content.Load<Texture2D>("walk_up_02"), 8, 3, Content.Load<Texture2D>("walk_up_02"), 8, 3,
                    5, 5, 5, 5, 5, 100, "Olaf", Content.Load<Texture2D>("Portrait Blondie"), Content.Load<Texture2D>("Blondie Dead"), Content.Load<Texture2D>("Blondie dead still"));

            mechanic2.ID = 2;

            ListOfChars.statListChar.Add(dora);
            ListOfChars.statListChar.Add(mechanic);
            ListOfChars.statListChar.Add(mechanic2);
            ListOfChars.statListChar.Add(spencer);
            ListOfChars.statListChar.Add(lavender);

            p = new ErrorMessage(mechanic, mechanic2, dora, spencer, lavender, resource);

            //Initializing events
            RoomCamera2 = Content.Load<Texture2D>("Engineroom05");
            RoomCamera3 = Content.Load<Texture2D>("infirmary003");
            RoomCamera4 = Content.Load<Texture2D>("kitchen_02");
            RoomTextures.Add(RoomCamera2);
            RoomTextures.Add(RoomCamera3);
            RoomTextures.Add(RoomCamera4);
            roomTab2 = new RoomTab(tab1Texture, new Vector2(1500, 150), "engineRoom", RoomE.EngineRoom, RoomCamera2);
            roomTab3 = new RoomTab(tab2Texture, new Vector2(1500, 250), "Infirmary", RoomE.Infirmary, RoomCamera3);
            roomTab4 = new RoomTab(tab3Texture , new Vector2(1500, 350), "Kitchen", RoomE.Kitchen, RoomCamera4);
            RoomTabs.Add(roomTab2);
            RoomTabs.Add(roomTab3);
            RoomTabs.Add(roomTab4);
           
            //Initializing variables
            maxEvents = 5;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            //loads all colors
            testFont = Content.Load<SpriteFont>("TestFont");
            fontSmall = Content.Load<SpriteFont>("CsFontSmall");
            matKnapp = Content.Load<Texture2D>("Mat knapp");
            sjukvårdsKnapp = Content.Load<Texture2D>("Sjukvårds knapp");
            repairKnapp = Content.Load<Texture2D>("Repair_knapp");
            ProblemMenuBackground = Content.Load<Texture2D>("ProblemMenu");
            yesButton = Content.Load<Texture2D>("YesButton");
            noButton = Content.Load<Texture2D>("NoButton");

            //loads rectangles
            repairKnappRectangle = new Rectangle(125, 3, 111, 83);
            sjukvårdsKnappRectangle = new Rectangle(125, 103, 111, 83);
            matKnappRectangle = new Rectangle(125, 203, 111, 83);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
                this.Exit();

            
            
            
            
                
            


            if (gameState == GameState.PreStart)
            {
                preStartScreen.Update(gameTime);

                if (preStartScreen.Pressed == true)
                {
                    gameState = GameState.StartMenu;
                }
            }

            if (gameState == GameState.StartMenu)
            {
                startButton.Update(gameTime);
                creditsButton.Update(gameTime);
                quitButton.Update(gameTime);

                if (startButton.Pressed == true)
                {
                    gameState = GameState.Intro;
                }
                if (quitButton.Pressed == true)
                {
                    this.Exit();
                }
            }
            if (gameState == GameState.Intro)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    gameState = GameState.Game;
                }
            }

            if (gameState == GameState.Game)
            {
                if (resource.Hull < 75)
                {
                    resource.Oxygen -= 0.02f;
                }
                else if (resource.Hull < 50)
                {
                    resource.Oxygen -= 0.03f;
                }
                else if (resource.Hull < 10)
                {
                    resource.Oxygen -= 0.04f;
                }
                if (resource.Hull <= 0)
                {
                    resource.Oxygen -= 5f;
                }
                if (resource.Oxygen <= 0)
                {
                    gameState = GameState.Lose;
                }
                HealthLossTimer++;
                if (HealthLossTimer >= 360 && resource.Oxygen < 20)
                {
                    for (int i = 0; i < ListOfChars.statListChar.Count; i++)
                    {
                        ListOfChars.statListChar[i].healthPoints -= 1;
                        temp = 0;
                        HealthLossTimer = 0;
                    }
                }
                if (HealthLossTimer == 120)
                {
                    for (int i = 0; i < ListOfChars.statListChar.Count; i++)
                    {
                        if (ListOfChars.statListChar[i].Hunger <= 0)
                        {
                            ListOfChars.statListChar[i].healthPoints -= 1;
                        }
                    }
                }
                for (int i = 0; i < ListOfChars.statListChar.Count; i++)
                {
                    
                    if (ListOfChars.statListChar[i].healthPoints <= 0)
                    {
                        ListOfChars.statListChar[i].IsDead = true;
                    }
                    
                    if (lel == 5)
                    {
                        gameState = GameState.Lose;
                    }
                    Debug.WriteLine(lel);
                }

                //Updates diffrent game objects and adds the seconds to the clock
                mechanic.Update(gameTime);
                mechanic2.Update(gameTime);
                dora.Update(gameTime);
                lavender.Update(gameTime);
                spencer.Update(gameTime);

                //roomTab1.Update(gameTime);
                roomTab2.Update(gameTime);
                roomTab3.Update(gameTime);
                roomTab4.Update(gameTime);
                //roomTab5.Update(gameTime);
                //roomTab6.Update(gameTime);


                



                b.Scroll(GraphicsDevice);

                resource.MaxAndMinResource();

                elevator.Update(gameTime);
                radar.Update(gameTime);
                screen.Update(gameTime);

                if (Keyboard.GetState().IsKeyDown(Keys.D1))
                {
                    gameSpeed = 1;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D2))
                {
                    gameSpeed = 3;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D3))
                {
                    gameSpeed = 10;
                }
            
                clock = clock.AddMilliseconds(16.6666666666667 * gameSpeed);
            
                p.SchedueldAlertMessage(clock, yesButton, new Vector2(75, 75), noButton);
                p.Update(spriteBatch, testFont, new Vector2(75, 75), yesButton, noButton, new Vector2());
                if (resource.Fuel != 0)
                {
                    foreach (SchedueldEvent e in ListOfEvents.StatListEvents.Where(x => x.GetType() == typeof(SchedueldEvent)))
                    {
                        distance = e.Piloting(distance, resource);
                        resource.Fuel -= 0.2398f;
                    }
                }
                foreach (ScanningEvent s in ListOfEvents.StatListEvents.Where(x => x.GetType() == typeof(ScanningEvent)))
                {
                    if (StaticGameHelper.scrapFound == true)
                    {
                        resource.ScrapMetal += rand.Next(20, 100);
                        StaticGameHelper.scrapFound = false;
                    }
                }
                //Update function for both the yes and the no buttons
                foreach (YesButton yes in ListOfYNButtons.ButtonList)
                {
                    yes.Update(gameTime);
                }
                foreach (NoButton no in ListOfYNButtons.ButtonList2)
                {
                    no.Update(gameTime);
                }
                foreach (Button but in buttonList)
                {
                    but.Update(gameTime);
                }

                if (mechanic.characterSelected) { mechanic2.characterSelected = false; dora.characterSelected = false; spencer.characterSelected = false; lavender.characterSelected = false; }
                if (mechanic2.characterSelected) { mechanic.characterSelected = false; dora.characterSelected = false; spencer.characterSelected = false; lavender.characterSelected = false; }
                if (dora.characterSelected) { mechanic.characterSelected = false; mechanic2.characterSelected = false; spencer.characterSelected = false; lavender.characterSelected = false; }
                if (lavender.characterSelected) { mechanic2.characterSelected = false; dora.characterSelected = false; spencer.characterSelected = false; mechanic.characterSelected = false; }
                if (spencer.characterSelected) { mechanic.characterSelected = false; mechanic2.characterSelected = false; dora.characterSelected = false; lavender.characterSelected = false;}

                if (distance == 1080000)
                {
                    gameState = GameState.Win;
                }

                base.Update(gameTime);
            }
            if (gameState == GameState.Lose)
            {
                loseScreen.Update(gameTime);
            }
            if (gameState == GameState.Win)
            {
                mechanic.Update(gameTime);
                mechanic2.Update(gameTime);
                dora.Update(gameTime);
                lavender.Update(gameTime);
                spencer.Update(gameTime);

                elevator.Update(gameTime);
                radar.Update(gameTime);
                screen.Update(gameTime);

                b.Scroll(GraphicsDevice);

                victoryPos.X += 1;
                if (victoryPos.X > 500)
                {
                    victoryPos.X = 500;
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            if (gameState == GameState.PreStart)
            {
                spriteBatch.Draw(preStartScreen.Texture, preStartScreen.Position, Color.White);
            }
            if (gameState == GameState.StartMenu)
            {
                spriteBatch.Draw(spaceBackground, new Vector2(0, 0), Color.White);
                startButton.Draw(spriteBatch);
                quitButton.Draw(spriteBatch);
                creditsButton.Draw(spriteBatch);
                startButton.TextOnButton(spriteBatch, testFont);
                quitButton.TextOnButton(spriteBatch, testFont);
                creditsButton.TextOnButton(spriteBatch, testFont);
            }
            if (gameState == GameState.Intro)
            {
                spriteBatch.Draw(introScreen, new Vector2(0, 0), Color.White);
            }

            if (gameState == GameState.Game)
            {

                b.Draw(spriteBatch);
                spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                elevator.Draw(spriteBatch);
                radar.Draw(spriteBatch);
                screen.Draw(spriteBatch);

                for (int i = 0; i < ListOfEvents.StatListEvents.Count; i++)
                {
                    ListOfEvents.StatListEvents[i].CurrentTime = clock;
                    ListOfEvents.StatListEvents[i].Update();
                }

                resource.Draw(spriteBatch, testFont);
                //engineEvent.DrawText(spriteBatch, testFont, new Vector2(100, 700));
                mechanic.Draw(spriteBatch);
                mechanic2.Draw(spriteBatch);
                dora.Draw(spriteBatch);
                lavender.Draw(spriteBatch);
                spencer.Draw(spriteBatch);
                mechanic.Talk(spriteBatch, fontSmall);
                mechanic2.Talk(spriteBatch, fontSmall);
                dora.Talk(spriteBatch, fontSmall);
                lavender.Talk(spriteBatch, fontSmall);
                spencer.Talk(spriteBatch, fontSmall);
                spriteBatch.DrawString(testFont, clock.ToLongTimeString(), new Vector2(3, 2), Color.White);
            
                p.Draw(spriteBatch,testFont,ProblemMenuBackground,new Vector2(314,5),fontSmall, clock);
                
                foreach (Button but in buttonList)
                {
                    but.Draw(spriteBatch);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.H))//replace Key with File capinet button instead or some other more imersive game mechanic
                {
                
                    for (int i = 0; i < ListOfEvents.StatListEvents.Count; i++)
                    {
                        spriteBatch.DrawString(testFont, ListOfEvents.StatListEvents[i].EventName, new Vector2(1200, 20 * i), Color.White);
                        spriteBatch.DrawString(testFont, ListOfEvents.StatListEvents[i].ETC.ToLongTimeString(), new Vector2(1062, 20 * i), Color.White);
                    }
                }


            foreach (RoomTab r in RoomTabs)
            {
                r.Draw(spriteBatch);
            }
            spriteBatch.DrawString(testFont, distance.ToString(), new Vector2(1500, 0), Color.White);

                foreach (YesButton yes in ListOfYNButtons.ButtonList)
                {
                    yes.Draw(spriteBatch);
                }
                foreach (NoButton no in ListOfYNButtons.ButtonList2)
                {
                    no.Draw(spriteBatch);
                }
                spriteBatch.Draw(menu, new Vector2(-2, 538), Color.White);
                mechanic.DrawText(spriteBatch, testFont);
                mechanic2.DrawText(spriteBatch, testFont);
                dora.DrawText(spriteBatch, testFont);
                lavender.DrawText(spriteBatch, testFont);
                spencer.DrawText(spriteBatch, testFont);

                foreach (RoomTab r in RoomTabs)
                {
                    r.Draw(spriteBatch);
                }

            }

            if (gameState == GameState.Lose)
            {
                loseScreen.Draw(spriteBatch);
            }

            if (gameState == GameState.Win)
            {
                b.Draw(spriteBatch);
                spriteBatch.Draw(victoryTexture, victoryPos, Color.White);
                spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                elevator.Draw(spriteBatch);
                radar.Draw(spriteBatch);
                screen.Draw(spriteBatch);

                mechanic.Draw(spriteBatch);
                mechanic2.Draw(spriteBatch);
                dora.Draw(spriteBatch);
                lavender.Draw(spriteBatch);
                spencer.Draw(spriteBatch);

                spriteBatch.DrawString(testFont, "YOU WIN!!", new Vector2(700, 400), Color.White);
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }

    enum GameState
    {
        PreStart,
        StartMenu,
        Game,
        End,
        Credits,
        Lose,
        Win,
        Intro

    }
}