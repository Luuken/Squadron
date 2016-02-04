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
    static class ListOfYNButtons
    {
        //lists that the other classes can use Ex: NoButton.cs, YesButton.cs, ErrorMessage.cs and Game1.cs
        //the class ErrorMessage.cs adds to these lists
        static public List<YesButton> ButtonList = new List<YesButton>();
        static public List<NoButton> ButtonList2 = new List<NoButton>();
    }
}
