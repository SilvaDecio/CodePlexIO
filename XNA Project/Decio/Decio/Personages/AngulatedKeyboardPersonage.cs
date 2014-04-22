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
    class AngulatedKeyboardPersonage : Personage
    {
        public AngulatedKeyboardPersonage(Viewport screen, ContentManager Content)
        {
            Screen = screen;
            
            Image = Content.Load<Texture2D>("Asset");

            Position = new Vector2();

            Speed = 5f;

            BoundingRectangle = new Rectangle((int)Position.X , (int)Position.Y ,
                Image.Width , Image.Height);

            Angle = 0f;
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Angle += 0.1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Angle -= 0.1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down))
            {
                Position.X += (float)Math.Cos(Angle) * (Speed);
                Position.Y += (float)Math.Sin(Angle) * (Speed);
            }

            Position.X = MathHelper.Clamp(Position.X, 0, Screen.Width - Image.Width);
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