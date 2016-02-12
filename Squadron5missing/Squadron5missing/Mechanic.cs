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
        Down,
        Dead
    }

    class Mechanic : Character
    {
        //properties
        public string WrenchName { get; set; }
        public Resources Resource { get; set; }
        public Vector2 OldPos { get; set; }
        public Texture2D OldTexture { get; set; }
        public Texture2D Portrait { get; set; }
        public Texture2D DeathAnim { get; set; }
        public int OldFrames { get; set; }
        public int OldSPR { get; set; }
        public int ID { get; set; }
        public Texture2D DeadTexture { get; set; }

        Direction direction = Direction.None;
        ButtonName selectedOption = ButtonName.Default;
        List<Button> buttonList = new List<Button>();
        Random rand = new Random();
        
        
        //boolean(s)
        bool hasCreatedButtons = false;
        public bool resolvePressed = false;
        public bool yesIsSelected = false;
        bool healSelected = false;
        bool hasDiedAnimated = false;

        int deathTimer = 0;
        int timer;
        string heyytext;

        //contructor(s)
        public Mechanic(Texture2D texture, Vector2 position, RoomE room, Resources resource, string name, int animWidth, int animHeight, int maxFrames, int spritesPerRow, Button button1, Button button2, Button button3, Button button4, Texture2D walkLeft, int walkLeftFrames, int walkLeftSPR, Texture2D walkRight, int walkRightFrames, int walkRightSPR,
            Texture2D walkUp, int walkUpFrames, int walkUpSPR, Texture2D walkDown, int walkDownFrames, int walkDownSPR, int intel, int perc, int stam, int con, int hand, int hunger, string wName, Texture2D portrait, Texture2D deathAnim, Texture2D deadTexture)
            : base(texture, position, room, name, animWidth, animHeight, maxFrames, spritesPerRow, button1, button2, button3, button4, walkLeft, walkLeftFrames, walkLeftSPR, walkRight, walkRightFrames, walkRightSPR, walkUp, walkUpFrames, walkUpSPR, walkDown, walkDownFrames, walkDownSPR, intel, perc, stam, con, hand, hunger)
        {
            this.WrenchName = wName;
            this.Resource = resource;
            this.healthPoints = (con * 2) * 10;
            this.OldPos = position;
            this.OldTexture = texture;
            this.OldSPR = spritesPerRow;
            this.OldFrames = maxFrames;
            this.Portrait = portrait;
            this.DeathAnim = deathAnim;
            this.DeadTexture = deadTexture;
        }

        //method(s)
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (IsDead == true)
            {
                characterSelected = false;
                if (hasDiedAnimated == false)
                {
                    Texture = DeathAnim;
                    direction = Direction.Dead;
                    AnimWidth = 300;
                    AnimHeight = 301;
                    MaxFrames = 8;
                    SpritesPerRow = 3;
                    deathTimer++;
                    if (deathTimer == MaxFrames)
                    {
                        hasDiedAnimated = true;
                    }
                }
                if (hasDiedAnimated == true)
                {
                    Texture = DeadTexture;
                    MaxFrames = 1;
                }
            }

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
                spriteBatch.DrawString(font, "Health: " + healthPoints, new Vector2(Position.X + 10, Position.Y - 30), Color.White);
                spriteBatch.DrawString(font, "Hunger: " + Math.Round(Hunger), new Vector2(Position.X + 10, Position.Y - 10), Color.White);
                spriteBatch.DrawString(font, CharName, new Vector2(20, 560), Color.White);

                spriteBatch.Draw(Portrait, new Vector2(70, 580), Color.White);
            }

            base.DrawText(spriteBatch, font);
        }
        public void Talk(SpriteBatch s, SpriteFont f)
        {
            List<string> heyyy= new List<string>();
            Random rnd = new Random();
            heyyy.Add("Is there life on mars?");
            heyyy.Add("Can you here me major tom?");
            heyyy.Add("Hi.");
            heyyy.Add("is this real life, or is just fantasy?");
            heyyy.Add("no one can here me scream in space?\nAAAAAAAAAHHHHH!!!!!");
            heyyy.Add("Mom get the camera!");
            heyyy.Add("got mems?");
            heyyy.Add("How do you get a baby astruonaut too sleep, you rocket...");
            heyyy.Add("Why didn't the sun go too college, he already had a million degrees");
            heyyy.Add("what do you call a crazy moon, a lunatic");
            heyyy.Add("I heard there's a new restaurant on the Moon, but it lacks atmosphere");
            heyyy.Add("our ship hangs in the sky in much the same way that bricks don't.");
            heyyy.Add("It's not a phase DAD!");
            heyyy.Add("Two dating astronauts met up for a launch date.");
            heyyy.Add("Why did the cow go in the space ship? \nHe wanted to see the moon!");
            heyyy.Add("Little is known about the inhabbitants \nof planet-837 Sector:B Orchid \n but they like PB&Js'");
            heyyy.Add("When i return to earth everyone\nwill want my rare space memes");
            heyyy.Add("We don't acctualy know the Super-engine\nworks, but it does so...");
            heyyy.Add("The food here? it's fine I guess?");
            heyyy.Add("do you come here often?");
            heyyy.Add("knock knock, wait this won't work...");
            heyyy.Add("what happens if a red and a blue spaceship crash together? Everyone dies...");

            int tempi = rand.Next(1, 2301);
            
            
            if (tempi == 2)
            {
                if (timer == 0)
                {
                    timer = 240;
                    heyytext = heyyy[rnd.Next(1, 22)];
                }
            }
            if (timer > 0)
            {
                s.DrawString(f, heyytext, new Vector2(Position.X - 30, Position.Y - 30), Color.White);
                timer--;
            }
        }
    }
}
