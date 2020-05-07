using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles
{
    public class ParticleSource
    {
        Random rand;

        private ParticleSystem partSys;
        public Vector2 sourcePosition;

        public ParticleSource(Vector2 sourcePosition)
        {
            rand = new Random();
            this.sourcePosition = sourcePosition;
            partSys = new ParticleSystem();
        }

        public void Generate(Texture2D texture)
        {
            float rotation = (float)(rand.NextDouble() * 2 * Math.PI);
            float vX = (float)(Math.Cos(rotation) * (rand.NextDouble() * 3));
            float vY = (float)(Math.Sin(rotation) * (rand.NextDouble() * 3));
            //                               texture, position,       tint,        scale,               velocity,            acceleration  decelerationFactor, lifeSpan
            partSys.AddParticle(new Particle(texture, sourcePosition, Color.Green, new Vector2(2f, 2f), new Vector2(vX, vY), Vector2.Zero, 0.98f,              rand.Next(50, 150)));
        }

        public void Update(GameTime gameTime, Viewport screen)
        {
            partSys.Update(gameTime, screen);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            partSys.Draw(spriteBatch);
        }
    }
}
