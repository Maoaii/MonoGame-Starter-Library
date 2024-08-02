using System;
using Microsoft.Xna.Framework;
using src.Behaviours.DataClasses;
using src.Entities;

namespace src.Behaviours.Physics
{
    public class Gravity : EntityBehaviour, IPhysicalBehaviour
    {
        private JumpAndGravity gravityResource;

        private float JumpGravity => (float)(-2 * gravityResource.JumpHeight / Math.Pow(gravityResource.JumpTimeToPeak, 2)) * -1;
        private float FallGravity => (float)(-2 * gravityResource.JumpHeight / Math.Pow(gravityResource.JumpTimeToDescent, 2)) * -1;
        public Gravity(Entity parent, JumpAndGravity gravityResource)
        {
            this.parent = parent;
            this.gravityResource = gravityResource;
        }

        public void Update(GameTime gameTime)
        {
            if (parent.Velocity.Y < 0)
            {
                parent.Velocity = new Vector2(parent.Velocity.X, parent.Velocity.Y + (JumpGravity * Globals.Time));
            }
            else
            {
                parent.Velocity = new Vector2(parent.Velocity.X, parent.Velocity.Y + (FallGravity * Globals.Time));
            }
        }
    }
}