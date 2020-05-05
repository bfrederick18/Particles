using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles
{
    public class AcceleratingSprite : MovingSprite
    {
        protected Vector2 acceleration;

        public AcceleratingSprite(Texture2D texture, Vector2 position, Color tint, Vector2 scale, Vector2 velocity, Vector2 acceleration)
           : base(texture, position, tint, scale, velocity)
        {
            this.acceleration = acceleration;
        }

        public AcceleratingSprite(Texture2D texture, Vector2 position, Vector2 scale, Vector2 velocity, Vector2 acceleration)
           : this(texture, position, Color.White, scale, velocity, acceleration)
        {

        }

        public override void Update(GameTime gameTime, Viewport screen)
        {
            velocity += acceleration;
            base.Update(gameTime, screen);
        }
    }
}
