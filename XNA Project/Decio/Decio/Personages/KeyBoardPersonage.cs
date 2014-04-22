using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using Decio.Animation;
using Decio.Personages.Base;

namespace Decio.Personages
{
    class KeyBoardPersonage : AnimatedPersonage
    {
        public KeyBoardPersonage(Viewport screen , ContentManager Content)
        {
            Screen = screen;

            Sprites = new Dictionary<Direction, Sprite>();

            //Sprites.Add(Direction.Idle, new Sprite());
            //Sprites.Add(Direction.Up, new Sprite());
            //Sprites.Add(Direction.Down, new Sprite());
            //Sprites.Add(Direction.Left, new Sprite());
            //Sprites.Add(Direction.Right, new Sprite());

            Position = new Vector2();

            Speed = 5f;

            CurrentDirection = Direction.Up;

            BoundingRectangle = new Rectangle((int)Position.X,(int)Position.Y,
                Sprites[CurrentDirection].AnimationRectangle.Width ,
                Sprites[CurrentDirection].AnimationRectangle.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (CurrentDirection != Direction.Up)
                {
                    Sprites[CurrentDirection].Restart();

                    CurrentDirection = Direction.Up;
                }

                Position.Y -= Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (CurrentDirection != Direction.Down)
                {
                    Sprites[CurrentDirection].Restart();
                
                    CurrentDirection = Direction.Down;
                }

                Position.Y += Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (CurrentDirection != Direction.Left)
                {
                    Sprites[CurrentDirection].Restart();
                
                    CurrentDirection = Direction.Left;
                }

                Position.X -= Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (CurrentDirection != Direction.Right)
                {
                    Sprites[CurrentDirection].Restart();
                    
                    CurrentDirection = Direction.Right;
                }

                Position.X += Speed;
            }
            else
            {
                if (CurrentDirection != Direction.Idle)
                {
                    Sprites[CurrentDirection].Restart();

                    CurrentDirection = Direction.Idle;
                }
            }

            Position.X = MathHelper.Clamp(Position.X, 0, Screen.Width - Sprites[CurrentDirection].AnimationRectangle.Width);

            Position.Y = MathHelper.Clamp(Position.Y, 0, Screen.Height - Sprites[CurrentDirection].AnimationRectangle.Height);

            BoundingRectangle = new Rectangle((int)Position.X, (int)Position.Y,
                Sprites[CurrentDirection].AnimationRectangle.Width, Sprites[CurrentDirection].AnimationRectangle.Width);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprites[CurrentDirection].Draw(spriteBatch, Position);
        }
    }
}