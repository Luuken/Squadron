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
    class ForegroundObject
    {
        Texture2D Texture { get; set; }
        Vector2 Position { get; set; }
        int AnimWidth { get; set; }
        int AnimHeight { get; set; }
        int MaxFrames { get; set; }
        int SpritesPerRow { get; set; }
        int AnimationDelay { get; set; }

        private int animationDelayTimer = 0;
        private int frame = 0;

        public ForegroundObject(Texture2D texture, Vector2 pos, int animWidth, int animHeight, int maxFrames, int spritesPerRow, int animationDelay)
        {
            this.Texture = texture;
            this.Position = pos;
            this.AnimWidth = animWidth;
            this.AnimHeight = animHeight;
            this.MaxFrames = maxFrames;
            this.SpritesPerRow = spritesPerRow;
            this.AnimationDelay = animationDelay;
        }

        public void Update(GameTime gameTime)
        {
            animationDelayTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (animationDelayTimer >= AnimationDelay)
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
            Rectangle tmp = new Rectangle((frame % SpritesPerRow) * AnimWidth, (frame / SpritesPerRow) * AnimHeight, AnimWidth, AnimHeight);
            spriteBatch.Draw(this.Texture, this.Position, tmp, Color.White);
        }
    }
}
