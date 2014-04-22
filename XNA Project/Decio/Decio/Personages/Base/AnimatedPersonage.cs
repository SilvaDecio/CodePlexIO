using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Decio.Animation;

namespace Decio.Personages.Base
{
    class AnimatedPersonage : Personage
    {
        protected Dictionary<Direction, Sprite> Sprites;
    }
}