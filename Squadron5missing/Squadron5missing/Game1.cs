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
        EngineEvent engineEvent;

        Resources resource;

        //Put all foreground objects here
        ForegroundObject chair;
        ForegroundObject elevator;
        ForegroundObject alarm;

        Random rand;
        //List<string> alertList = new List<string>();
        List<Event> alertListv2 = new List<Event>();
        List<Button> buttonList;

        Texture2D ProblemMenuBackground;
        Texture2D background;
        Texture2D menu;
        Texture2D spaceBackground;

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

        GameState gameState = GameState.PreStart;

        ErrorMessage p;
        bool gameLost = false;
        public int gameSpeed = 1;
        public double distance = 0;
        int temp;
        int maxEvents;
        

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

            b = new BackScroll(Content.Load<Texture2D>("space02"), Content.Load<Texture2D>("space03"), .03f);
            background = Content.Load<Texture2D>("room_02");
            menu = Content.Load<Texture2D>("menu_layout");
            preStartScreen = new Button(Content.Load<Texture2D>("start00"), new Vector2(0,0), Color.White, ButtonName.Default);

            startButton = new Button(Content.Load<Texture2D>("Start Button"), new Vector2(GraphicsDevice.Viewport.Width - 300, 50), Color.White, ButtonName.Start);
            creditsButton = new Button(Content.Load<Texture2D>("Start Button"), new Vector2(GraphicsDevice.Viewport.Width - 300, 350), Color.White, ButtonName.Credits);
            quitButton = new Button(Content.Load<Texture2D>("Start Button"), new Vector2(GraphicsDevice.Viewport.Width - 300, 650), Color.White, ButtonName.Quit);

            chair = new ForegroundObject(Content.Load<Texture2D>("chair02"), new Vector2(762, 430), 150, 150, 2, 2, 400);
            elevator = new ForegroundObject(Content.Load<Texture2D>("elevator_002"), new Vector2(352, 264), 500, 500, 13, 4, 100);
            alarm = new ForegroundObject(Content.Load<Texture2D>("Larm"), new Vector2(GraphicsDevice.Viewport.Width - 107, 46), 300, 300, 1, 1, 10000);

            this.IsMouseVisible = true;

            spaceBackground = Content.Load<Texture2D>("Space BG");
            
            base.Initialize();

            RoomTabs = new List<RoomTab>();
            RoomTextures = new List<Texture2D>();

            resource = new Resources(Content.Load<Texture2D>("resource_button"), new Vector2(2, 18), testFont, spriteBatch, 200, 300, 100, 3000, 100);

            buttonList = new List<Button>();
            
            //Setting graphics settings
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            rand = new Random();
            //Initializing characters
            /*spencer = new Mechanic(Content.Load<Texture2D>("spencer_idle_02"), new Vector2(600, 500), RoomE.Bridge, resource, "Spencer Bara", 300, 300, 3, 2, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("spencer_idle_02"), 8, 3, Content.Load<Texture2D>("spencer_idle_02"), 8, 3, Content.Load<Texture2D>("spencer_walk_up_03"), 8, 3, Content.Load<Texture2D>("spencer_walk_up_03"), 8, 3, 5, 5, 5, 5, 5, 100, "");*/

            dora = new Mechanic(Content.Load<Texture2D>("Dora Hairflip"), new Vector2(700, 400), RoomE.Bridge, resource, "Dora the Explorah", 174, 300, 13, 5, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("Dora Walk Left"), 8, 5, Content.Load<Texture2D>("Dora Walk Right"), 8, 5, Content.Load<Texture2D>("Dora Walk Back"), 8, 5, Content.Load<Texture2D>("Dora Walk Front"), 8, 5, 5, 5, 5, 5, 5, 100, "");

            dora.ID = 3;

            mechanic = new Mechanic(Content.Load<Texture2D>("Kitty Breath Blink"), new Vector2(1000, 450), RoomE.Bridge, resource, "Morgan the Mechanic", 174, 300, 9, 5, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("Kitty Walk Left"), 8, 5, Content.Load<Texture2D>("Kitty Walk Right"), 8, 5, Content.Load<Texture2D>("Kitty Walk Back"), 9, 5, Content.Load<Texture2D>("Kitty Walk Front"), 9, 5, 5, 5, 5, 8, 5, 100, "Olaf");

            mechanic.ID = 1;

            mechanic2 = new Mechanic(Content.Load<Texture2D>("idle_pose02"), new Vector2(300, 450), RoomE.Bridge, resource, "Morgan the Mechanic", 300, 300, 8, 3, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("walk_right_03"), 8, 3, Content.Load<Texture2D>("walk_right_03"), 8, 3, Content.Load<Texture2D>("walk_up_02"), 8, 3, Content.Load<Texture2D>("walk_up_02"), 8, 3, 5, 5, 5, 5, 5, 100, "Olaf");

            mechanic2.ID = 2;

            ListOfChars.statListChar.Add(dora);
            ListOfChars.statListChar.Add(mechanic);
            ListOfChars.statListChar.Add(mechanic2);

            p = new ErrorMessage(mechanic, mechanic2, dora, resource);

            //Initializing events

            //engineEvent = new EngineEvent(200, "Engine broke down", clock, "The engines Fluxual Accelerate Perperator has been damaged and needs repair");

            RoomCamera1 = Content.Load<Texture2D>("button");
            RoomCamera2 = Content.Load<Texture2D>("button");
            RoomCamera3 = Content.Load<Texture2D>("button");
            RoomCamera4 = Content.Load<Texture2D>("button");
            RoomCamera5 = Content.Load<Texture2D>("button");
            RoomCamera6 = Content.Load<Texture2D>("button");
            RoomTextures.Add(RoomCamera1);
            RoomTextures.Add(RoomCamera2);
            RoomTextures.Add(RoomCamera3);
            RoomTextures.Add(RoomCamera4);
            RoomTextures.Add(RoomCamera5);
            RoomTextures.Add(RoomCamera6);
            roomTab1 = new RoomTab(sjukvårdsKnapp, new Vector2(1500, 50), "bridge", RoomE.Bridge, RoomTextures);
            roomTab2 = new RoomTab(repairKnapp, new Vector2(1500, 150), "engineRoom", RoomE.EngineRoom, RoomTextures);
            roomTab3 = new RoomTab(sjukvårdsKnapp, new Vector2(1500, 250), "cockpit", RoomE.Cockpit, RoomTextures);
            roomTab4 = new RoomTab(sjukvårdsKnapp, new Vector2(1500, 350), "infermary", RoomE.Infirmary, RoomTextures);
            roomTab5 = new RoomTab(sjukvårdsKnapp, new Vector2(1500, 450), "kitchen", RoomE.Kitchen, RoomTextures);
            roomTab6 = new RoomTab(sjukvårdsKnapp, new Vector2(1500, 550), "battlestation", RoomE.Battlestation, RoomTextures);
            RoomTabs.Add(roomTab1);
            RoomTabs.Add(roomTab2);
            RoomTabs.Add(roomTab3);
            RoomTabs.Add(roomTab4);
            RoomTabs.Add(roomTab5);
            RoomTabs.Add(roomTab6);
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

            
            if (resource.Hull < 50)
            {
                resource.Oxygen -= 0.02f;
            }
            if (resource.Hull < 25)
            {
                resource.Oxygen -= 0.03f;
            }
            if (resource.Hull < 10)
            {
                resource.Oxygen -= 0.03f;
            }
            if (resource.Hull <= 0)
	        {
                resource.Oxygen -= 5f;
	        }
            if (resource.Oxygen <= 0)
            {
                gameLost = true;
            }


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
                    gameState = GameState.Game;
                }
                if (quitButton.Pressed == true)
                {
                    this.Exit();
                }
            }

            if (gameState == GameState.Game)
            {


            //Updates diffrent game objects and adds the seconds to the clock
            mechanic.Update(gameTime);
            mechanic2.Update(gameTime);
            dora.Update(gameTime);
            //spencer.Update(gameTime);

            roomTab1.Update();
            roomTab2.Update();
            roomTab3.Update();
            roomTab4.Update();
            roomTab5.Update();
            roomTab6.Update();

            b.Scroll(GraphicsDevice);

            resource.MaxAndMinResource();

            chair.Update(gameTime);
            elevator.Update(gameTime);

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
                Debug.WriteLine("Size of list: " + ListOfEvents.StatListEvents.Count);
                Debug.WriteLine("Number of SE: " + ListOfEvents.StatListEvents.Where(x => x.GetType() == typeof(SchedueldEvent)).ToList().Count.ToString());
                foreach (SchedueldEvent e in ListOfEvents.StatListEvents.Where(x => x.GetType() == typeof(SchedueldEvent)))
                {
                    distance = e.Piloting(distance, resource);
                    resource.Fuel -= 0.2398f;
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

            if (mechanic.characterSelected) { mechanic2.characterSelected = false; dora.characterSelected = false;}
            if (mechanic2.characterSelected) { mechanic.characterSelected = false; dora.characterSelected = false;}
            if (dora.characterSelected) { mechanic.characterSelected = false; mechanic2.characterSelected = false;}
            //if (spencer.characterSelected) { mechanic.characterSelected = false; mechanic2.characterSelected = false; dora.characterSelected = false; }
            
            

            base.Update(gameTime);
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
            }

            if (gameState == GameState.Game)
            {

                b.Draw(spriteBatch);
                spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                chair.Draw(spriteBatch);
                elevator.Draw(spriteBatch);
                alarm.Draw(spriteBatch);

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

                spriteBatch.DrawString(testFont, clock.ToLongTimeString(), new Vector2(3, 2), Color.White);
            
                p.Draw(spriteBatch,testFont,ProblemMenuBackground,new Vector2(332,5),fontSmall, clock);
            
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

                foreach (RoomTab r in RoomTabs)
                {
                    r.Draw(spriteBatch);
                }

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
        Credits
    }
}