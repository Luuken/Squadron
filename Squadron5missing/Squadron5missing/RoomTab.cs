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
        public RoomE RoomCam { get; set; }
        public List<Texture2D> RoomTextures { get; set; }


        bool buttonPressed1 = false;
        bool buttonRealeased1 = true;
        bool drawRoom = false;
        private MouseState prevMouse;
        //members
        Texture2D roomTexture;
        Vector2 roomPositon;


        //constructor(s)
        public RoomTab(Texture2D texture, Vector2 position, string roomName, RoomE roomCam, List<Texture2D> roomTextures)
        {
            this.Position = position;
            this.RoomName = roomName;
            this.Texture = texture;
            this.RoomCam = roomCam;
            this.RoomTextures = roomTextures;
        }
        //Method(s)
        public void Update()
        {
            if (Mouse.GetState().X > Position.X && Mouse.GetState().X < (Position.X + Texture.Width))
            {
                if (Mouse.GetState().Y > Position.Y && Mouse.GetState().Y < (Position.Y + Texture.Height))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && prevMouse.LeftButton == ButtonState.Released)
                    {
                        drawRoom = !drawRoom;
                    }
                }
            }
            prevMouse = Mouse.GetState();
        }
        public void Draw(SpriteBatch s)
        {
            s.Draw(Texture, Position, Color.White);
            //s.DrawString(testFont, RoomName, Position, Color.White);
            if (drawRoom == true)
            {
                DrawRoom(s);
            }
        }
        //använda rum enum?? eller rum string
        public void DrawRoom(SpriteBatch s)
        {
            for (int i = 0; i < RoomTextures.Count; i++)
            {
                if (i == (int)RoomCam)
                {
                    s.Draw(RoomTextures[i], new Vector2(1385, 725), Color.White);
                }
            }
            for (int i = 0; i < ListOfChars.statListChar.Count; i++)
            {
                if ((int)RoomCam == (int)ListOfChars.statListChar[i].RoomV)
                {
                    //s.Draw(ListOfChars.statListChar[i].Texture, )
                }
            }
        }

    }
}
