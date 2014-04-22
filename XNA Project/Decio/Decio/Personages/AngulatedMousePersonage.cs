using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using Decio.Personages.Base;

namespace Decio.Personages
{
    class AngulatedMousePersonage : Personage
    {        
        Vector2 VetorialSpeed , Distance;

        public AngulatedMousePersonage(Viewport screen, ContentManager Content)
        {
            Screen = screen;

            Image = Content.Load<Texture2D>("Asset");

            Position = new Vector2();

            VetorialSpeed = new Vector2(5,5);

            BoundingRectangle = new Rectangle((int)Position.X , (int)Position.Y ,
                Image.Width , Image.Height);

            Angle = 0f;

            Distance = new Vector2();
        }

        public void Update(GameTime gameTime)
        {
            Distance.X = Position.X - Mouse.GetState().X;
            Distance.Y = Position.Y - Mouse.GetState().Y;

            Angle = (float)Math.Atan2(Distance.Y, Distance.X);

            if (Distance.Length() > 1)
            {
                Position.X -= (float)(Math.Cos(Angle));
                Position.Y -= (float)(Math.Sin(Angle)); 
            }

            Position.X = MathHelper.Clamp(Position.X, 0, Screen.Width - Image.Height);
            Position.Y = MathHelper.Clamp(Position.Y, 0, Screen.Height - Image.Height);

            BoundingRectangle.X = (int)Position.X;
            BoundingRectangle.Y = (int)Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, null, Color.White, Angle,
                new Vector2(Image.Width / 2,Image.Height / 2),1f, SpriteEffects.None, 0f);
        }
    }
}