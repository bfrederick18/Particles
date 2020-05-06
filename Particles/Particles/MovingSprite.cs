﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles
{
    public class MovingSprite : BaseSprite
    {
        protected Vector2 velocity;

        public MovingSprite(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color tint, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, Vector2 velocity)
            : base(texture, position, sourceRectangle, tint, rotation, origin, scale, effects, layerDepth)
        {
            this.velocity = velocity;
        }

        public MovingSprite(Texture2D texture, Vector2 position, Color tint, Vector2 scale, Vector2 velocity)
            : this(texture, position, new Rectangle(0, 0, texture.Width, texture.Height), tint, 0f, scale, Vector2.One, SpriteEffects.None, 0, velocity) { }

        public MovingSprite(Texture2D texture, Vector2 position, Vector2 scale, Vector2 velocity)
           : this(texture, position, Color.White, scale, velocity) { }

        public override void Update(GameTime gameTime, Viewport screen)
        {
            position += velocity;
            base.Update(gameTime, screen);
        }
    }
}
