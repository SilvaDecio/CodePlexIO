using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Decio.Particle
{
    class ParticleEmitter
    {
        List<Texture2D> Textures;

        List<Particle> Particles;

        Vector2 Position;

        Random Raffle;

        float AdditionTime , ElapsedTime;
        
        int MaxParticles;

        public ParticleEmitter(Vector2 position , float addTime , int maxParticles , params Texture2D[] textures)
        {
            Position = position;

            Textures = textures.ToList();

            Particles = new List<Particle>();

            Raffle = new Random();

            AdditionTime = addTime;
            ElapsedTime = 0f;

            MaxParticles = maxParticles;
        }

        public void Update(GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            if (ElapsedTime >= AdditionTime)
            {
                ElapsedTime = 0f;

                if (Particles.Count < MaxParticles)
                {
                    Particles.Add(RandomParticle());
                }
            }

            for (int i = Particles.Count; i >= 0; i--)
            {
                Particles[i].Update(gameTime);

                if (Particles[i].LifeTime <= 0f)
                {
                    Particles.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = Particles.Count; i >= 0; i--)
            {
                Particles[i].Draw(spriteBatch);
            }
        }

        public Particle RandomParticle()
        {
            // Seleciona uma imagem aleatória da lista
            Texture2D texture = Textures[Raffle.Next(Textures.Count)];

            // Velocidade aleatória da partícula
            Vector2 speed = new Vector2(
                1f * (float)(Raffle.NextDouble() * 2 - 1),
                1f * (float)(Raffle.NextDouble() * 2 - 1));

            // Velocidade randomica angular da partícula
            float angularSpeed = 0.1f * (float)(Raffle.NextDouble() * 2 - 1);
            
            // Tempo de vida da partícula
            float lifeTime = 20 + Raffle.Next(40);

            return new Particle(texture, Position, speed, angularSpeed, lifeTime);
        }
    }
}