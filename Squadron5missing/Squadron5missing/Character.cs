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
        kitchen,
        Battlestation
    }
    class Character
    {
        //properties
        protected Texture2D Texture { get; set; }
        protected Vector2 Position { get; set; }
        protected RoomE RoomV { get; set; }

        //stats(properties)
        protected int Intellect { get; set; } //medics and ship tweaking
        protected int Perception { get; set; } //piloting and being on watch
        protected int Stamina { get; set; } //rapairs and fights
        protected int Constitution { get; set; } //not getting sick
        protected int Handyness { get; set; } //general handyness and workspeed also repairs
        
        

        //boolean(s)
        

        //constructor(s)
        protected Character(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }

        //method(s) add Update and Draw functions!



    }
}
