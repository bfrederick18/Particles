using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles
{
    public class ParticleSystem
    {
        private List<Particle> particles;

        public ParticleSystem()
        {
            particles = new List<Particle>();
        }

        public void AddParticle(Particle part)
        {
            particles.Add(part);
        }

        public void Update(GameTime gameTime, Viewport screen)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Update(gameTime, screen);
                if (particles[i].lifeSpan <= 0)
                {
                    particles.Remove(particles[i]);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Particle e in particles)
            {
                e.Draw(spriteBatch);
            }
        }

    }
}
