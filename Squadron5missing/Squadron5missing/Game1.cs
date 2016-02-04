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
        EngineEvent engineEvent;


        ForegroundObject chair;

        Random rand;
        //List<string> alertList = new List<string>();
        List<Event> alertListv2 = new List<Event>();

        Texture2D ProblemMenuBackground;
        Texture2D background;

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
        int gameSpeed = 1;
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

            b = new BackScroll(Content.Load<Texture2D>("space02"), Content.Load<Texture2D>("space03"), .2f);
            background = Content.Load<Texture2D>("background01");

            chair = new ForegroundObject(Content.Load<Texture2D>("chair01"), new Vector2(687, 360), 300, 300, 2);

            this.IsMouseVisible = true;
            
            base.Initialize();

            //Setting graphics settings
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            rand = new Random();
            //Initializing characters
            mechanic = new Mechanic(Content.Load<Texture2D>("character 1"), new Vector2(1000, 250), RoomE.Bridge, "Morgan the Mechanic", 131, 500, 1, 5, 5, 5, 5, 5, "Olaf");

            p = new ErrorMessage();

            //Initializing events
            engineEvent = new EngineEvent(200, "Engine broke down", clock, "The engines Fluxual Accelerate Perperator has been damaged and needs repair");

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

            testFont = Content.Load<SpriteFont>("TestFont");
            fontSmall = Content.Load<SpriteFont>("CsFontSmall");
            matKnapp = Content.Load<Texture2D>("Mat knapp");
            sjukvårdsKnapp = Content.Load<Texture2D>("Sjukvårds knapp");
            repairKnapp = Content.Load<Texture2D>("Repair_knapp");
            ProblemMenuBackground = Content.Load<Texture2D>("ProblemMenu");
            yesButton = Content.Load<Texture2D>("YesButton");
            noButton = Content.Load<Texture2D>("NoButton");

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
            mechanic.Update(gameTime);
            b.Scroll(GraphicsDevice);

            chair.Update(gameTime);
            
            clock = clock.AddMilliseconds(16.6666666666667 * gameSpeed);
            p.SchedueldAlertMessage(clock);
            //e.CurrentTime = clock;
            //e.Update();
            p.Update(spriteBatch, testFont, new Vector2(75, 75));
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

            //engineEvent.DrawText(spriteBatch, testFont, new Vector2(100, 700));
            mechanic.Draw(spriteBatch);
            spriteBatch.DrawString(testFont, clock.ToLongTimeString(), new Vector2(3, 2), Color.White);
            
           
            p.Draw(spriteBatch,testFont,ProblemMenuBackground,new Vector2(332,5),fontSmall);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
