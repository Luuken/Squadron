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
    public enum RoomE
    {
        Bridge,
        EngineRoom,
        Cockpit,
        Infirmary,
        Kitchen,
        Battlestation
    }
    class Character
    {
        //properties
        protected Texture2D Texture { get; set; }
        protected Vector2 Position { get; set; }
        public RoomE RoomV { get; set; }
        protected string CharName { get; set; }
        protected int AnimWidth { get; set; }
        protected int AnimHeight { get; set; }
        protected int MaxFrames { get; set; }
        protected int SpritesPerRow { get; set; }
        protected Button CharButton1 { get; set; }
        protected Button CharButton2 { get; set; }
        protected Button CharButton3 { get; set; }
        protected Button CharButton4 { get; set; }
        protected Texture2D WalkLeft { get; set; }
        protected int WalkLeftFrames { get; set; }
        protected int WalkLeftSpritesPerRow { get; set; }
        protected Texture2D WalkRight { get; set; }
        protected int WalkRightFrames { get; set; }
        protected int WalkRightSpritesPerRow { get; set; }
        protected Texture2D WalkUp { get; set; }
        protected int WalkUpFrames { get; set; }
        protected int WalkUpSpritesPerRow { get; set; }
        protected Texture2D WalkDown { get; set; }
        protected int WalkDownFrames { get; set; }
        protected int WalkDownSpritesPerRow { get; set; }

        //stats(properties)
        protected int Intellect { get; set; } //medics and ship tweaking
        protected int Perception { get; set; } //piloting and being on watch
        protected int Stamina { get; set; } //rapairs and fights
        protected int Constitution { get; set; } //not getting sick
        protected int Handyness { get; set; } //general handyness and workspeed also repairs
        protected float Hunger { get; set; }

        //private members
        private int frame = 0;
        private int animationDelayTimer = 0;
        private int animationDelay = 200;
        protected int gameSpeed = 1;
        
        

        //boolean(s)
        public bool characterSelected = false;

        //constructor(s)
        protected Character(Texture2D texture, Vector2 position, RoomE room, string name, int animWidth, int animHeight, int maxFrames, int spritesPerRow,
            Button button1, Button button2, Button button3, Button button4, Texture2D walkLeft, int walkLeftFrames, int walkLeftSPR, Texture2D walkRight, int walkRightFrames, int walkRightSPR,
            Texture2D walkUp, int walkUpFrames, int walkUpSPR, Texture2D walkDown, int walkDownFrames, int walkDownSPR, int intel, int perc, int stam, int con, int hand, float hunger)
        {
            this.Texture = texture;
            this.Position = position;
            this.RoomV = room;
            this.CharName = name;
            this.AnimHeight = animHeight;
            this.AnimWidth = animWidth;
            this.MaxFrames = maxFrames;
            this.SpritesPerRow = spritesPerRow;
            this.CharButton1 = button1;
            this.CharButton2 = button2;
            this.CharButton3 = button3;
            this.CharButton4 = button4;
            this.WalkLeft = walkLeft;
            this.WalkLeftFrames = walkLeftFrames;
            this.WalkLeftSpritesPerRow = walkLeftSPR;
            this.WalkRight = walkRight;
            this.WalkRightFrames = walkRightFrames;
            this.WalkRightSpritesPerRow = walkRightSPR;
            this.WalkUp = walkUp;
            this.WalkUpFrames = walkUpFrames;
            this.WalkUpSpritesPerRow = walkUpSPR;
            this.WalkDown = walkDown;
            this.WalkDownFrames = walkDownFrames;
            this.WalkDownSpritesPerRow = walkDownSPR;

            this.Intellect = intel;
            this.Perception = perc;
            this.Stamina = stam;
            this.Constitution = con;
            this.Handyness = hand;
            this.Hunger = hunger;
        }

        //method(s) add Update and Draw functions!
        public virtual void Update(GameTime gameTime)
        {
            if (Mouse.GetState().X > Position.X && Mouse.GetState().X < (Position.X + AnimWidth))
            {
                if (Mouse.GetState().Y > Position.Y && Mouse.GetState().Y < (Position.Y + AnimHeight))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        characterSelected = true;
                    }
                }
            }

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

            Hunger -= 0.005f * gameSpeed;
            if (Hunger > 100)
            {
                Hunger = 100;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                characterSelected = false;
            }

            
            //AnimationUpdate
            animationDelayTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (animationDelayTimer >= animationDelay)
            {
                animationDelayTimer = 0;
                frame++;
                if (frame >= MaxFrames)
                {
                    frame = 0;
                }
            }

            Debug.WriteLine(frame);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle tmp = new Rectangle((frame % SpritesPerRow) * AnimWidth, (frame / SpritesPerRow) * AnimHeight, AnimWidth, AnimHeight);
            spriteBatch.Draw(this.Texture, this.Position, tmp, Color.White);
        }

        public virtual void DrawText(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (characterSelected == true)
            {
            spriteBatch.DrawString(font, ButtonName.Eat.ToString(), new Vector2(575, 680), Color.White);
            spriteBatch.DrawString(font, ButtonName.Resolve.ToString(), new Vector2(970, 680), Color.White);
            spriteBatch.DrawString(font, ButtonName.Heal.ToString(), new Vector2(575, 810), Color.White);
            spriteBatch.DrawString(font, ButtonName.Upgrade.ToString(), new Vector2(970, 810), Color.White);
            }
        }


    }
}
