using System;
using Microsoft.Xna.Framework;
using src.Entities;

namespace src.Behaviours.Physics
{
    public class Gravity : EntityBehaviour, IPhysicalBehaviour
    {
        private Vector2 acceleration;
        public Gravity(Entity parent, Vector2 acceleration)
        {
            this.parent = parent;
            this.acceleration = acceleration;
        }

        public void Update(GameTime gameTime)
        {
            parent.Velocity += new Vector2(0, acceleration.Y);
        }
    }
}