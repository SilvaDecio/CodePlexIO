using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Decio.Energy
{
    class EnergyBar
    {
        Texture2D BoxImage , EnergyImage;

        Vector2 BoxPosition, EnergyPosition;

        float MaxEnergy , Recovery , RecoveryFactor;

        public float Energy;

        bool IsFlip , HasRecoverybar;

        Color FullColor , Emptycolor , RecoveryColor;

        public EnergyBar(Texture2D boxImage , Texture2D energyImage , Vector2 boxPosition , Vector2 energyPosition ,
            bool Flip , bool Recovery , float recoveryFactor , Color fullColor , Color emptyColor , Color recoveryColor)
        {
            BoxImage = boxImage;
            EnergyImage = energyImage;

            BoxPosition = boxPosition;
            EnergyPosition = energyPosition;

            IsFlip = Flip;
            HasRecoverybar = Recovery;

            FullColor = fullColor;
            Emptycolor = emptyColor;
            RecoveryColor = recoveryColor;

            RecoveryFactor = recoveryFactor;
            MaxEnergy = 100.0f;
            Energy = MaxEnergy;
        }

        public void Draw(GameTime gameTime , SpriteBatch spriteBatch)
        {
            if (HasRecoverybar)
            {
                Recovery -= RecoveryFactor * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Recovery = MathHelper.Clamp(Recovery, Energy, MaxEnergy);

                spriteBatch.Draw(EnergyImage , EnergyPosition , new  Rectangle(0, 0,
                    (int)(Recovery * EnergyImage.Width / MaxEnergy), (int)EnergyImage.Height) , RecoveryColor ,
                    IsFlip ? MathHelper.ToRadians(180) : 0.0f ,
                    IsFlip ? new Vector2(EnergyImage.Width, EnergyImage.Height) : Vector2.Zero,
                    1.0f , SpriteEffects.None , 0.0f);
            }

            spriteBatch.Draw(BoxImage , BoxPosition , new Rectangle(0, 0,
                BoxImage.Width, BoxImage.Height) , Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);

            spriteBatch.Draw(EnergyImage , EnergyPosition ,new Rectangle(0, 0,
                (int)(Energy * EnergyImage.Width / MaxEnergy) , (int)EnergyImage.Height) ,
                Color.Lerp(Emptycolor , FullColor , Energy / MaxEnergy) ,
                IsFlip ? MathHelper.ToRadians(180) : 0.0f,
                IsFlip ? new Vector2(EnergyImage.Width , EnergyImage.Height) : Vector2.Zero ,
                1.0f , SpriteEffects.None , 0.0f);
        }

        
        public void FullRecovery()
        {
            Energy = MaxEnergy;
            Recovery = MaxEnergy;
        }

        public void MaxRecovery()
        {
            Recovery = Energy;
        }

        public void MoveTo(Vector2 NewPosition)
        {
            Vector2 Distance = EnergyPosition - BoxPosition;
            BoxPosition = NewPosition;
            EnergyPosition = BoxPosition + Distance;
        }
    }
}