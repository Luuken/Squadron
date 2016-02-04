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
        protected RoomE RoomV { get; set; }
        protected string CharName { get; set; }
        protected int AnimWidth { get; set; }
        protected int AnimHeight { get; set; }
        protected int MaxFrames { get; set; }

        //stats(properties)
        protected int Intellect { get; set; } //medics and ship tweaking
        protected int Perception { get; set; } //piloting and being on watch
        protected int Stamina { get; set; } //rapairs and fights
        protected int Constitution { get; set; } //not getting sick
        protected int Handyness { get; set; } //general handyness and workspeed also repairs

        //private members
        private int frame = 0;
        private int animationDelayTimer = 0;
        private int animationDelay = 200;
        
        

        //boolean(s)
        bool characterSelected = false;

        //constructor(s)
        protected Character(Texture2D texture, Vector2 position, RoomE room, string name, int animWidth, int animHeight, int maxFrames, int intel, int perc, int stam, int con, int hand)
        {
            this.Texture = texture;
            this.Position = position;
            this.RoomV = room;
            this.CharName = name;
            this.AnimHeight = animHeight;
            this.AnimWidth = animWidth;
            this.MaxFrames = maxFrames;

            this.Intellect = intel;
            this.Perception = perc;
            this.Stamina = stam;
            this.Constitution = con;
            this.Handyness = hand;
        }

        //method(s) add Update and Draw functions!
        public virtual void Update(GameTime gameTime)
        {
            if (Mouse.GetState().X > Position.X && Mouse.GetState().X < (Position.X + Texture.Width))
            {
                if (Mouse.GetState().Y > Position.Y && Mouse.GetState().Y < (Position.Y + Texture.Height))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        characterSelected = true;
                    }
                }
            }

            
            //AnimationUpdate
            animationDelayTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (animationDelayTimer >= animationDelay)
            {
                animationDelayTimer = 0;
                frame++;
                if (frame == MaxFrames)
                {
                    frame = 0;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle tmp = new Rectangle((frame % 2) * AnimWidth, (frame / 2) * AnimHeight, AnimWidth, AnimHeight);
            spriteBatch.Draw(this.Texture, this.Position, tmp, Color.White);
        }

        public virtual void DrawText(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (characterSelected == true)
            {
            spriteBatch.DrawString(font, ButtonName.Eat.ToString(), new Vector2(575, 600), Color.White);
            spriteBatch.DrawString(font, ButtonName.Resolve.ToString(), new Vector2(900, 600), Color.White);
            spriteBatch.DrawString(font, ButtonName.Talk.ToString(), new Vector2(575, 775), Color.White);
            spriteBatch.DrawString(font, ButtonName.Tweak.ToString(), new Vector2(900, 775), Color.White);
            }
        }


    }
}
