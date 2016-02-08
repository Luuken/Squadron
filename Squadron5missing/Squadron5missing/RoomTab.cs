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

        //members
        Texture2D roomTexture;
        Vector2 roomPositon;

        //constructor(s)
        public RoomTab(Texture2D texture, Vector2 position, string roomName)
        {
            this.Position = position;
            this.RoomName = roomName;
            this.Texture = texture;
        }
        //Method(s)
        public void Update()
        {
            if (Mouse.GetState().X > Position.X && Mouse.GetState().X < (Position.X + Texture.Width))
            {
                if (Mouse.GetState().Y > Position.Y && Mouse.GetState().Y < (Position.Y + Texture.Height))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        DrawRoom();
                    }
                }
            }
        }
        public void Draw(SpriteBatch s, SpriteFont testFont)
        {
            s.Draw(Texture, Position, Color.White);
            s.DrawString(testFont, RoomName, Position, Color.White);
        }
        //använda rum enum?? eller rum string
        public void DrawRoom()
        {

        }

    }
}
