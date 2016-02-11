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
    enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    class Mechanic : Character
    {
        //properties
        public string WrenchName { get; set; }
        public Resources Resource { get; set; }
        public Vector2 OldPos { get; set; }
        public Texture2D OldTexture { get; set; }
        public int OldFrames { get; set; }
        public int OldSPR { get; set; }
        public int ID { get; set; }

        Direction direction = Direction.None;
        ButtonName selectedOption = ButtonName.Default;
        List<Button> buttonList = new List<Button>();

        int healthPoints;
        
        //boolean(s)
        bool hasCreatedButtons = false;
        public bool resolvePressed = false;
        public bool yesIsSelected = false;
        bool healSelected = false;

        //contructor(s)
        public Mechanic(Texture2D texture, Vector2 position, RoomE room, Resources resource, string name, int animWidth, int animHeight, int maxFrames, int spritesPerRow, Button button1, Button button2, Button button3, Button button4, Texture2D walkLeft, int walkLeftFrames, int walkLeftSPR, Texture2D walkRight, int walkRightFrames, int walkRightSPR,
            Texture2D walkUp, int walkUpFrames, int walkUpSPR, Texture2D walkDown, int walkDownFrames, int walkDownSPR, int intel, int perc, int stam, int con, int hand, int hunger, string wName)
            : base(texture, position, room, name, animWidth, animHeight, maxFrames, spritesPerRow, button1, button2, button3, button4, walkLeft, walkLeftFrames, walkLeftSPR, walkRight, walkRightFrames, walkRightSPR, walkUp, walkUpFrames, walkUpSPR, walkDown, walkDownFrames, walkDownSPR, intel, perc, stam, con, hand, hunger)
        {
            this.WrenchName = wName;
            this.Resource = resource;
            this.healthPoints = (con * 2) * 10;
            this.OldPos = position;
            this.OldTexture = texture;
            this.OldSPR = spritesPerRow;
            this.OldFrames = maxFrames;
        }

        //method(s)
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            

            if (characterSelected == true && hasCreatedButtons == false)
            {
                hasCreatedButtons = true;
                buttonList.Add(CharButton1);
                buttonList.Add(CharButton2);
                buttonList.Add(CharButton3);
                buttonList.Add(CharButton4);
            }

            if (hasCreatedButtons == true && characterSelected)
            {
                foreach (Button b in buttonList)
                {
                    b.Update(gameTime);
                    if(b.Pressed)
                    {
                        selectedOption = b.BName;
                    }
                }
            }


            if (healSelected)
            {
                if (Position == new Vector2(400, 350))
                {
                    direction = Direction.None;
                    Position = new Vector2(-500, -500);
                }
                else if (Position.X > 400)
                {
                    Position = new Vector2(Position.X - 1, Position.Y);
                    direction = Direction.Left;
                }
                else if (Position.X < 400)
                {
                    Position = new Vector2(Position.X + 1, Position.Y);
                    direction = Direction.Right;
                }
                else if (Position.X == 400 && Position.Y > 350)
                {
                    Position = new Vector2(Position.X, Position.Y - 1);
                    direction = Direction.Up;
                }
            }

            if (yesIsSelected)
            {
                if (Position == new Vector2(-500, -500))
                {
                    direction = Direction.None;
                    for (int i = 0; i < ListOfEvents.StatListEvents.Count; i++)
                    {
                        if (ListOfEvents.StatListEvents[i].eventFinished == true)                  
                        {
                            if(ListOfEvents.StatListEvents[i].Chara.ID == this.ID)
                            {
                                yesIsSelected = false;
                                Position = OldPos;
                                ListOfEvents.StatListEvents.RemoveAt(i);
                            }
                        }
                    }
                }
                else if (Position == new Vector2(400, 350))
                {
                    direction = Direction.None;
                    Position = new Vector2(-500, -500);
                }
                else if (Position.X > 400)
                {
                    Position = new Vector2(Position.X - 1, Position.Y);
                    direction = Direction.Left;
                }
                else if (Position.X < 400)
                {
                    Position = new Vector2(Position.X + 1, Position.Y);
                    direction = Direction.Right;
                }
                else if (Position.X == 400 && Position.Y > 350)
                {
                    Position = new Vector2(Position.X, Position.Y - 1);
                    direction = Direction.Up;
                }
            }


            if (selectedOption == ButtonName.Resolve)
            {
                resolvePressed = true;
                selectedOption = ButtonName.Default;
                //Position = new Vector2((Position.X - 1.3f), Position.Y);
                //direction = Direction.Left;
            }
            else if (selectedOption == ButtonName.Eat)
            {
                if (Resource.Food - 25 >= 0)
                {
                    Resource.Food -= 25;
                    Hunger += 10;
                    selectedOption = ButtonName.Default;
                }
            }
            else if (selectedOption == ButtonName.Heal)
            {
                healSelected = true;
                selectedOption = ButtonName.Default;
            }
            else if (selectedOption == ButtonName.Upgrade)
            {
                if (Resource.ScrapMetal - 35 >= 0)
                {
                Resource.Hull += 10;
                Resource.ScrapMetal -= 35;
                selectedOption = ButtonName.Default;
                }
            }

            if (direction == Direction.Left)
            {
                Texture = WalkLeft;
                SpritesPerRow = WalkLeftSpritesPerRow;
                MaxFrames = WalkLeftFrames;
                characterIdle = false;
            }
            else if (direction == Direction.Right)
            {
                Texture = WalkRight;
                SpritesPerRow = WalkRightSpritesPerRow;
                MaxFrames = WalkRightFrames;
                characterIdle = false;
            }
            else if (direction == Direction.Up)
            {
                Texture = WalkUp;
                SpritesPerRow = WalkUpSpritesPerRow;
                MaxFrames = WalkUpFrames;
                characterIdle = false;
            }
            else if (direction == Direction.Down)
            {
                Texture = WalkDown;
                SpritesPerRow = WalkDownSpritesPerRow;
                MaxFrames = WalkDownFrames;
                characterIdle = false;
            }
            else if (direction == Direction.None)
            {
                Texture = OldTexture;
                SpritesPerRow = OldSPR;
                MaxFrames = OldFrames;
                characterIdle = true;
            }


            
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            /*if (characterSelected)
            {
                foreach (Button b in buttonList)
                {
                    b.Draw(spriteBatch);
                }
            }*/
        }
        public override void DrawText(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (characterSelected)
            {
                spriteBatch.DrawString(font, "Health: " + healthPoints, new Vector2(Position.X + 10, Position.Y - 24), Color.White);
                spriteBatch.DrawString(font, "Hunger: " + Math.Round(Hunger), new Vector2(Position.X + 10, Position.Y - 10), Color.White);
            }

            base.DrawText(spriteBatch, font);
        }
    }
}
