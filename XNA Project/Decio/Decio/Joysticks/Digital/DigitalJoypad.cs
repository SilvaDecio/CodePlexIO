using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Decio.Joysticks.Digital
{
    class DigitalJoypad
    {
        public Pad Top, Bottom, Left, Right;

        public DigitalJoypad(ContentManager Content , Vector2 Position)
        {
            //Top = new Pad();
            //Bottom = new Pad();
            //Left = new Pad();
            //Right = new Pad();
        }

        public void Update(GameTime gameTime , List<Vector2> Positions)
        {
            Top.Hold = false;
            Bottom.Hold = false;
            Left.Hold = false;
            Right.Hold = false;

            for (int i = 0; i < Positions.Count; i++)
            {
                Point TouchedPlace = new Point( (int)Positions[i].X, (int)Positions[i].Y);

                if (Top.BoundingRectangle.Contains(TouchedPlace))
                {
                    Top.Hold = true;
                }
                else if (Bottom.BoundingRectangle.Contains(TouchedPlace))
                {
                    Bottom.Hold = true;
                }
                else if (Left.BoundingRectangle.Contains(TouchedPlace))
                {
                    Left.Hold = true;
                }
                else if (Right.BoundingRectangle.Contains(TouchedPlace))
                {
                    Right.Hold = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Top.Draw(spriteBatch);
            Bottom.Draw(spriteBatch);
            Right.Draw(spriteBatch);
            Left.Draw(spriteBatch);
        }
    }
}