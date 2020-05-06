using Microsoft.Xna.Framework;
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

        public void Generate()
        {

        }

    }
}
