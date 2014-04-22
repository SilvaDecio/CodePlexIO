using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Decio.Personages.Base
{
    class Personage
    {
        protected Texture2D Image;

        public Vector2 Position;

        protected float Speed;

        public Rectangle BoundingRectangle;

        public enum Direction
        {
            Up, Down, Left, Right , Idle
        }

        public Direction CurrentDirection;

        protected float Angle;

        protected Viewport Screen;
    }
}