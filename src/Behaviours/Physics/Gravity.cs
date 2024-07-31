using Microsoft.Xna.Framework;
using src.Entities;

namespace src.Behaviours.Physics
{
    public class Gravity : EntityBehaviour
    {
        private Vector2 acceleration;
        public Gravity(Entity parent, Vector2 acceleration)
        {
            this.parent = parent;
            this.acceleration = acceleration;
        }

        public override void Update(GameTime gameTime)
        {
            parent.Velocity += acceleration;
            ApplyGravity();
        }

        private void ApplyGravity()
        {
            parent.Position += parent.Velocity;
        }
    }
}