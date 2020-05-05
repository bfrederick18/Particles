using Microsoft.Xna.Framework;
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

        public MovingSprite(Texture2D texture, Vector2 position, Color tint, Vector2 scale, Vector2 velocity)
           : base(texture, position, tint, scale)
        {
            this.velocity = velocity;
        }

        public MovingSprite(Texture2D texture, Vector2 position, Vector2 scale, Vector2 velocity)
           : this(texture, position, Color.White, scale, velocity)
        {

        }
        public override void Update(GameTime gameTime, Viewport screen)
        {
            position += velocity;
            base.Update(gameTime, screen);
        }
    }
}
