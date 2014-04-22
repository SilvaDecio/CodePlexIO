using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Decio.Joysticks.Digital
{
    class Pad
    {
        Texture2D Image , HoldImage;

        Vector2 Position;

        public Rectangle BoundingRectangle;

        public bool Hold;

        public Pad(Texture2D image , Texture2D holdImage , Vector2 position)
        {
            Image = image;
            HoldImage = holdImage;

            Position = position;

            BoundingRectangle = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);

            Hold = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Hold)
            {
                spriteBatch.Draw(HoldImage, Position, Color.White);
            }
            else
            {
                spriteBatch.Draw(Image, Position, Color.White);
            }
        }
    }
}