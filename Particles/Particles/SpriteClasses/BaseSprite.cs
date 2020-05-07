using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles
{
    public class BaseSprite
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Rectangle sourceRectangle;
        protected Color tint;
        protected float rotation;
        protected Vector2 scale;
        protected float layerDepth;
        protected Vector2 origin;
        protected SpriteEffects effects;

        public BaseSprite(Texture2D texture, Vector2 position)
            : this(texture, position, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0)
        {
            origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
        }

        public BaseSprite(Texture2D texture, Vector2 position, Color tint, Vector2 scale)
            : this(texture, position)
        {
            this.tint = tint;
            this.scale = scale;
        }

        public BaseSprite(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color tint, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            this.texture = texture;
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.tint = tint;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effects = effects;
            this.layerDepth = layerDepth;
        }

        public virtual void Update(GameTime gameTime, Viewport screen)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, tint, rotation, origin, scale, effects, layerDepth);
        }
    }
}
