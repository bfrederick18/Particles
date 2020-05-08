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
        private ParticleSource partSource;
        public TimeSpan spawnSpeed;
        public DateTime lastSpawn;
        public int lifeSpan;
        private Tuple<Vector2, Vector2, Vector2> rgb;

        private Torch(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color tint, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, float transparency, Vector2 velocity, Vector2 acceleration, float decelerationFactor, Texture2D partTexture)
            : base(texture, position, sourceRectangle, tint, rotation, origin, scale, effects, layerDepth, transparency, velocity, acceleration, decelerationFactor)
        {
            rgb = new Tuple<Vector2, Vector2, Vector2>(new Vector2(235, 255), new Vector2(0, 255), new Vector2(0, 0));
            this.partTexture = partTexture;
            partSource = new ParticleSource(position - new Vector2(0, scale.Y * 11), new Vector2(0.5f, 1.2f), new Vector2(3f), 0.2f, rgb);
            spawnSpeed = new TimeSpan(0, 0, 0, 0, 100);
            lastSpawn = DateTime.Now;
            lifeSpan = rand.Next(150, 250);
        }

        public Torch(Texture2D texture, Vector2 position, Vector2 scale, float transparency, Vector2 velocity, Vector2 acceleration, float decelerationFactor, Texture2D partTexture)
            : this(texture, position, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0, transparency, velocity, acceleration, decelerationFactor, partTexture) { }

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
