using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using Decio.Animation;

namespace Decio.Objects
{
    class Object
    {
        protected Texture2D Image;

        protected Vector2 Position;
        
        public Rectangle BoundingRectangle;
        
        public Color[] Data;
        
        protected float Speed;
        
        protected SpriteEffects Effect;
        
        public Direction CurrentDirection;

        public enum Direction
        {
            Right , Left , Up , Down
        }

        public virtual void Update(GameTime gameTime)
        {}

        public virtual void Draw(SpriteBatch spriteBatch)
        {}
    }
}