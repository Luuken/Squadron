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

        //stats(properties)
        protected int Intellect { get; set; } //medics and ship tweaking
        protected int Perception { get; set; } //piloting and being on watch
        protected int Stamina { get; set; } //rapairs and fights
        protected int Constitution { get; set; } //not getting sick
        protected int Handyness { get; set; } //general handyness and workspeed also repairs

        //private members
        private int frame = 0;
        private int animationDelayTimer = 0;
        private int animationDelay = 100;
        
        

        //boolean(s)
        

        //constructor(s)
        protected Character(Texture2D texture, Vector2 position, RoomE room, string name, int animWidth, int animHeight, int intel, int perc, int stam, int con, int hand)
        {
            this.Texture = texture;
            this.Position = position;
            this.RoomV = room;
            this.CharName = name;
            this.AnimHeight = animHeight;
            this.AnimWidth = animWidth;

            this.Intellect = intel;
            this.Perception = perc;
            this.Stamina = stam;
            this.Constitution = con;
            this.Handyness = hand;
        }

        //method(s) add Update and Draw functions!
        public virtual void Update(GameTime gameTime)
        {
            animationDelayTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (animationDelayTimer >= animationDelay)
            {
                animationDelayTimer = 0;
                frame++;
                if (frame == 2)
                {
                    frame = 0;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle tmp = new Rectangle(frame * AnimWidth, 0, AnimWidth, AnimHeight);
            spriteBatch.Draw(this.Texture, this.Position, tmp, Color.White);
        }


    }
}
