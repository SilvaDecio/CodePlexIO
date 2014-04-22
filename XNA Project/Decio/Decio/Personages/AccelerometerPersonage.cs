using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Microsoft.Devices.Sensors;

using Decio.Animation;
using Decio.Personages.Base;

namespace Decio.Personages
{
    class AccelerometerPersonage : AnimatedPersonage
    {
        Accelerometer LocalAccelerometer;
        
        Vector2 LocalReading;

        public AccelerometerPersonage(Viewport screen , ContentManager Content)
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

            BoundingRectangle = new Rectangle((int)Position.X, (int)Position.Y,
                Sprites[CurrentDirection].AnimationRectangle.Width , Sprites[CurrentDirection].AnimationRectangle.Height);

            LocalReading = new Vector2();

            LocalAccelerometer = new Accelerometer();
            LocalAccelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged);
            LocalAccelerometer.Start();
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            LocalReading.X = e.SensorReading.Acceleration.Y;
            LocalReading.Y = e.SensorReading.Acceleration.X;
        }

        public void Update(GameTime gameTime)
        {
            Vector2 AbsoluteAcceleration = new Vector2(Math.Abs(LocalReading.X),
                Math.Abs(LocalReading.Y));

            if (LocalReading.Length() > 0.2f)
            {
                if (AbsoluteAcceleration.Y > AbsoluteAcceleration.X)
                {
                    if (LocalReading.Y > 0)
                    {
                        if (CurrentDirection != Direction.Up)
                        {
                            Sprites[CurrentDirection].Restart();

                            CurrentDirection = Direction.Up;
                        }

                        Position.Y -= Speed * AbsoluteAcceleration.Length();
                    }
                    else
                    {
                        if (CurrentDirection != Direction.Down)
                        {
                            Sprites[CurrentDirection].Restart();

                            CurrentDirection = Direction.Down;
                        }

                        Position.Y += Speed * AbsoluteAcceleration.Length();
                    }
                }
                else
                {
                    if (LocalReading.X > 0)
                    {
                        if (CurrentDirection != Direction.Left)
                        {
                            Sprites[CurrentDirection].Restart();

                            CurrentDirection = Direction.Left;
                        }

                        Position.X -= Speed * AbsoluteAcceleration.Length();
                    }
                    else
                    {
                        if (CurrentDirection != Direction.Right)
                        {
                            Sprites[CurrentDirection].Restart();

                            CurrentDirection = Direction.Right;
                        }

                        Position.X += Speed * AbsoluteAcceleration.Length();
                    }
                }
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
                Sprites[CurrentDirection].AnimationRectangle.Width, Sprites[CurrentDirection].AnimationRectangle.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprites[CurrentDirection].Draw(spriteBatch, Position);
        }
    }
}