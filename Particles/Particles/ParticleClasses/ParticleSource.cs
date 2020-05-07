﻿using Microsoft.Xna.Framework;
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
        public float minRadius;
        public float maxRadius;

        public ParticleSource(Vector2 sourcePosition, float minRadius, float maxRadius)
        {
            rand = new Random();

            this.sourcePosition = sourcePosition;
            partSys = new ParticleSystem();
            this.minRadius = minRadius;
            this.maxRadius = maxRadius;
        }

        public void Generate(Texture2D texture, int lifeSpan)
        {
            float rotation = (float)(rand.NextDouble() * 2 * Math.PI);
            double velMulti = (rand.NextDouble() * (maxRadius - minRadius)) + minRadius;
            float vX = (float)(Math.Cos(rotation) * velMulti);
            float vY = (float)(Math.Sin(rotation) * velMulti);
            //                               texture, position,       tint,        scale,               velocity,            acceleration  decelerationFactor, lifeSpan
            partSys.AddParticle(new Particle(texture, sourcePosition, Color.Green, new Vector2(2f, 2f), new Vector2(vX, vY), Vector2.Zero, 0.98f,              lifeSpan));
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