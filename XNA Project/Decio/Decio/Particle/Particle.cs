using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Decio.Particle
{
    class Particle
    {
        Texture2D Image;

        Vector2 Position , Speed;

        float AngularSpeed, Angle;

        public float LifeTime;

        public Particle(Texture2D image , Vector2 position , Vector2 speed , float angularSpeed , float lifeTime)
        {
            Image = image;

            Position = position;
            Speed = speed;

            AngularSpeed = angularSpeed;
            Angle = 0f;

            LifeTime = lifeTime;
        }

        public void Update(GameTime gameTime)
        {
            LifeTime--;
            Position += Speed;
            Angle += AngularSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, null, Color.White, Angle, new Vector2(Image.Width / 2, Image.Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}