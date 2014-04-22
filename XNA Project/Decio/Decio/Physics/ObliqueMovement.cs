using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Decio.Physics
{
    class ObliqueMovement
    {
        Texture2D Image;

        Vector2 Position , InitialSpeed , Speed , Direction , Impulse;

        float Angle , Gravity;

        public ObliqueMovement(ContentManager Content , Vector2 Delta)
        {
            Image = Content.Load<Texture2D>("");

            Position = new Vector2();

            // PC
            Angle = (float)Math.Atan2(Mouse.GetState().Y - Position.Y , Mouse.GetState().X - Position.X);

            // Phone
            Angle = (float)Math.Atan2(Delta.Y, Delta.X);

            Direction = new Vector2((float)Math.Cos(Angle) , (float)Math.Sin(Angle));

            //PC
            Impulse = new Vector2(5 , 10);

            // Phone
            Impulse = Delta;

            InitialSpeed = Impulse * Direction;

            Speed = InitialSpeed;

            Gravity = 0.1f;
        }

        public void Update(GameTime gameTime)
        {
            Speed.Y += Gravity;

            Position += Speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, Color.White);
        }
    }
}