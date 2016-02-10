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
        

        ErrorMessage p;
        public int gameSpeed = 1;
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

            chair = new ForegroundObject(Content.Load<Texture2D>("chair02"), new Vector2(762, 430), 150, 150, 2, 2, 400);
            elevator = new ForegroundObject(Content.Load<Texture2D>("elevator_002"), new Vector2(352, 264), 500, 500, 13, 4, 100);
            alarm = new ForegroundObject(Content.Load<Texture2D>("Larm"), new Vector2(GraphicsDevice.Viewport.Width - 107, 46), 300, 300, 1, 1, 10000);

            this.IsMouseVisible = true;
            
            base.Initialize();

            RoomTabs = new List<RoomTab>();
            RoomTextures = new List<Texture2D>();

            resource = new Resources(Content.Load<Texture2D>("resource_button"), new Vector2(2, 18), testFont, spriteBatch, 200, 300, 100, 3000, 100);

            buttonList = new List<Button>();
            
            //Setting graphics settings
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            rand = new Random();
            //Initializing characters
            mechanic = new Mechanic(Content.Load<Texture2D>("Kitty Breath Blink"), new Vector2(1000, 450), RoomE.Bridge, resource, "Morgan the Mechanic", 174, 300, 9, 5, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("Kitty Walk Left"), 8, 3, Content.Load<Texture2D>("Kitty Walk Right"), 8, 3, Content.Load<Texture2D>("Kitty Walk Back"), 9, 3, Content.Load<Texture2D>("Kitty Walk Front"), 9, 3, 5, 5, 5, 8, 5, 100, "Olaf");

            mechanic2 = new Mechanic(Content.Load<Texture2D>("idle_pose02"), new Vector2(300, 450), RoomE.Bridge, resource, "Morgan the Mechanic", 300, 300, 8, 3, new Button(Content.Load<Texture2D>("button"), new Vector2(400, 665), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 665), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(400, 790), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 790), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("walk_right_03"), 8, 3, Content.Load<Texture2D>("walk_right_03"), 8, 3, Content.Load<Texture2D>("walk_up_02"), 8, 3, Content.Load<Texture2D>("walk_up_02"), 8, 3, 5, 5, 5, 5, 5, 100, "Olaf");

            p = new ErrorMessage(mechanic, mechanic2);

            //Initializing events
            engineEvent = new EngineEvent(200, "Engine broke down", clock, "The engines Fluxual Accelerate Perperator has been damaged and needs repair");

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
            roomTab2 = new RoomTab(repairKnapp, new Vector2(1500, 500), "engineRoom", RoomE.EngineRoom, RoomTextures);
            roomTab3 = new RoomTab(sjukvårdsKnapp, new Vector2(1500, 150), "cockpit", RoomE.Cockpit, RoomTextures);
            roomTab4 = new RoomTab(sjukvårdsKnapp, new Vector2(1500, 200), "infermary", RoomE.Infirmary, RoomTextures);
            roomTab5 = new RoomTab(sjukvårdsKnapp, new Vector2(1500, 250), "kitchen", RoomE.Kitchen, RoomTextures);
            roomTab6 = new RoomTab(sjukvårdsKnapp, new Vector2(1500, 300), "battlestation", RoomE.Battlestation, RoomTextures);
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

            //Updates diffrent game objects and adds the seconds to the clock
            mechanic.Update(gameTime);
            mechanic2.Update(gameTime);


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

            if (mechanic.characterSelected) { mechanic2.characterSelected = false; }
            if (mechanic2.characterSelected) { mechanic.characterSelected = false; }
            
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            b.Draw(spriteBatch);
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            chair.Draw(spriteBatch);
            elevator.Draw(spriteBatch);
            alarm.Draw(spriteBatch);

            for (int i = 0; i < ListOfEvents.StatListEvents.Count; i++)
            {
                ListOfEvents.StatListEvents[i].Update();
                ListOfEvents.StatListEvents[i].CurrentTime = clock;
            }

            resource.Draw(spriteBatch, testFont);
            //engineEvent.DrawText(spriteBatch, testFont, new Vector2(100, 700));
            mechanic.Draw(spriteBatch);
            mechanic2.Draw(spriteBatch);

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

            foreach (RoomTab r in RoomTabs)
            {
                r.Draw(spriteBatch);
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
