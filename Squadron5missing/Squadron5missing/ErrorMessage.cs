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
    class ErrorMessage
    {
        public SpriteBatch SpriteBatch{ get; set; }
        public SpriteFont SFont { get; set; }
        public Vector2 position { get; set; }
        public string EventAlert { get; set; }

        Random rnd = new Random();
        

        //pilot Errors
        private string pErMessage1;
        private string pErMessage2;

        //radar Errors
        private string rErMessage3;
        private string rErMessage4;

        //infermary errors
        private string iErMessage5;

        //engine errors
        private string eErMessage6;
        private string eErMessage7;
        private string eErMessage8;

        public void DrawText(SpriteBatch spriteBatch, SpriteFont sFont, Vector2 position)
        {

        }
    }
}
