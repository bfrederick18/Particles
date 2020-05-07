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

        public Vector2 sourcePosition;
        private ParticleSystem partSys;
        public Vector2 radii;
        // (minRadius, maxRadius);
        public Vector2 scale;
        public Tuple<Vector2, Vector2, Vector2> rgb;
        public ParticleSource(Vector2 sourcePosition, Vector2 radii, Vector2 scale, Tuple<Vector2, Vector2, Vector2> rgb)
        {
            rand = new Random();

            this.sourcePosition = sourcePosition;
            partSys = new ParticleSystem();
            this.radii = radii;
            this.scale = scale;
            this.rgb = rgb;
        }

        public void Generate(Texture2D texture, int lifeSpan)
        {
            float rotation = (float)(rand.NextDouble() * 2 * Math.PI);
            double velMulti = (rand.NextDouble() * (radii.Y - radii.X)) + radii.X;
            float vX = (float)(Math.Cos(rotation) * velMulti);
            float vY = (float)(Math.Sin(rotation) * velMulti);
            Color partColor = new Color(rand.Next((int)rgb.Item1.X, (int)rgb.Item1.Y), rand.Next((int)rgb.Item2.X, (int)rgb.Item2.Y), rand.Next((int)rgb.Item3.X, (int)rgb.Item3.Y));

            //                               texture, position,       tint,      scale, velocity,            decelerationFactor, lifeSpan
            partSys.AddParticle(new Particle(texture, sourcePosition, partColor, scale, new Vector2(vX, vY), 0.98f,              lifeSpan));
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
