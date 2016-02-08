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
    class RoomTab
    {
        //properties
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public string RoomName { get; set; }

        //constructor(s)
        public RoomTab(Texture2D texture, Vector2 position, string roomName)
        {
            this.Position = position;
            this.RoomName = roomName;
            this.Texture = texture;
        }
        //Method(s)
    }
}
