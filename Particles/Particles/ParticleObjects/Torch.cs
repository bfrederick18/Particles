using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles.ParticleObjects
{
    public class Torch : AcceleratingSprite
    {
        public Texture2D partTexture;
        public ParticleSource partSource;
        private TimeSpan spawnSpeed;
        private DateTime lastSpawn;
        private int lifeSpan;

        private Torch(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color tint, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, Vector2 velocity, Vector2 acceleration, float decelerationFactor, Texture2D partTexture, ParticleSource partSource)
            : base(texture, position, sourceRectangle, tint, rotation, origin, scale, effects, layerDepth, velocity, acceleration, decelerationFactor)
        {
            this.partTexture = partTexture;
            this.partSource = partSource;
            spawnSpeed = new TimeSpan(0, 0, 0, 0, 70);
            lastSpawn = DateTime.Now;
            lifeSpan = rand.Next(50, 150);
        }

        public Torch(Texture2D texture, Vector2 position, Vector2 scale, Vector2 velocity, Vector2 acceleration, float decelerationFactor, Texture2D partTexture, ParticleSource partSource)
            : this(texture, position, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0, velocity, acceleration, decelerationFactor, partTexture, partSource) { }

        public override void Update(GameTime gameTime, Viewport screen)
        {
            if (DateTime.Now - lastSpawn >= spawnSpeed)
            {
                lastSpawn = DateTime.Now;
                partSource.Generate(partTexture, lifeSpan);
            }
            partSource.Update(gameTime, screen);
            base.Update(gameTime, screen);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            partSource.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
