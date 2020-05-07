using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Particles
{
    public class Particle : AcceleratingSprite
    {
        public int lifeSpan;

        public Particle(Texture2D texture, Vector2 position, Color tint, Vector2 scale, Vector2 velocity, Vector2 acceleration, float decelerationFactor, int lifeSpan)
            : base(texture, position, tint, scale, velocity, acceleration, decelerationFactor)
        {
            this.lifeSpan = lifeSpan;
        }

        public override void Update(GameTime gameTime, Viewport screen)
        {
            lifeSpan--;
            rotation += (float)(Math.PI / 4096 * lifeSpan);
            Console.WriteLine(rotation);
            base.Update(gameTime, screen);
        }
    }
}
