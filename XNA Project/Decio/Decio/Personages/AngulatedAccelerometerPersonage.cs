using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using Microsoft.Devices.Sensors;

using Decio.Personages.Base;

namespace Decio.Personages
{
    class AngulatedAccelerometerPersonage : Personage
    {        
        Vector2 Acceleration , VetorialSpeed;

        Accelerometer LocalAccelerometer;

        public AngulatedAccelerometerPersonage(Viewport screen, ContentManager Content)
        {
            Screen = screen;

            Image = Content.Load<Texture2D>("Asset");

            Position = new Vector2();

            VetorialSpeed = new Vector2(5,5);

            Acceleration = new Vector2();

            BoundingRectangle = new Rectangle((int)Position.X, (int)Position.Y,
                Image.Width , Image.Height);

            Angle = 0f;

            LocalAccelerometer = new Accelerometer();
            LocalAccelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<Microsoft.Devices.Sensors.AccelerometerReading>>(Accelerometer_CurrentValueChanged);
            LocalAccelerometer.Start();
        }

        void Accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Acceleration.X = -e.SensorReading.Acceleration.Y;
            Acceleration.Y = -e.SensorReading.Acceleration.X;
        }

        public void Update(GameTime gameTime)
        {
            VetorialSpeed += Acceleration;

            VetorialSpeed.X = MathHelper.Clamp(VetorialSpeed.X, -7.5f, 7.5f);
            VetorialSpeed.Y = MathHelper.Clamp(VetorialSpeed.Y, -7.5f, 7.5f);

            Position += VetorialSpeed;

            Angle = (float)Math.Atan2(VetorialSpeed.Y, VetorialSpeed.X);

            Position.X = MathHelper.Clamp(Position.X, 0, Screen.Width - Image.Width);
            Position.Y = MathHelper.Clamp(Position.Y, 0, Screen.Height - Image.Height);

            BoundingRectangle.X = (int)Position.X;
            BoundingRectangle.Y = (int)Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, null, Color.White, Angle,
                new Vector2(Image.Width / 2, Image.Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}