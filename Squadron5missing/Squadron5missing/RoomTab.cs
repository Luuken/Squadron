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
        public Texture2D RoomTextures { get; set; }


        bool buttonPressed1 = false;
        bool buttonRealeased1 = true;
        bool drawRoom = false;
        private MouseState prevMouse;
        //members
        Texture2D roomTexture;
        Vector2 roomPositon;

        private int animationDelayTimer = 0;
        private int frame = 0;


        //constructor(s)
        public RoomTab(Texture2D texture, Vector2 position, string roomName, RoomE roomCam, Texture2D roomTextures)
        {
            this.Position = position;
            this.RoomName = roomName;
            this.Texture = texture;
            this.RoomCam = roomCam;
            this.RoomTextures = roomTextures;
        }
        //Method(s)
        public void Update(GameTime gameTime)
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

            animationDelayTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (animationDelayTimer >= 100)
            {
                animationDelayTimer = 0;
                frame++;
                if (frame == 4)
                {
                    frame = 0;
                }
            }
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
            Rectangle tmp = new Rectangle((frame % 2) * 150, (frame / 2) * 84, 150, 84);
            s.Draw(this.RoomTextures, new Vector2(1400, 800), tmp, Color.White);
                
            for (int i = 0; i < ListOfChars.statListChar.Count; i++)
            {
                if ((int)RoomCam == (int)ListOfChars.statListChar[i].RoomV)
                {
                    //s.Draw(ListOfChars.statListChar[i].Texture, new Vector2(1390, 729), Color.White);
                }
            }
        }

    }
}
