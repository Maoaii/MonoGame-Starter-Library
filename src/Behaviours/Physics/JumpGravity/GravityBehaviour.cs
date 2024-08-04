using System;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Behaviours.DataClasses;
using MonoGameLibrary.Behaviours.Physics.JumpGravity;
using MonoGameLibrary.Entities;

namespace MonoGameLibrary.Behaviours.Physics
{
    public class GravityBehaviour : EntityBehaviour, IPhysicalBehaviour, IGravityBehaviour
    {
        private readonly JumpAndGravity gravityResource;
        public GravityBehaviour(Entity parent, JumpAndGravity gravityResource)
        {
            this.parent = parent;
            this.gravityResource = gravityResource;
        }

        public void Update(GameTime gameTime)
        {
            ApplyGravity(parent);
        }

        public float CalculateGravity(JumpAndGravity gravityResource, Entity entity)
        {
            if (entity.Velocity.Y < 0)
            {
                return (float)(-2 * gravityResource.JumpHeight / Math.Pow(gravityResource.JumpTimeToPeak, 2)) * -1;
            }
            else
            {
                return (float)(-2 * gravityResource.JumpHeight / Math.Pow(gravityResource.JumpTimeToDescent, 2)) * -1;
            }
        }

        public void ApplyGravity(Entity entity)
        {
            entity.Velocity = new Vector2(entity.Velocity.X, entity.Velocity.Y + (CalculateGravity(gravityResource, entity) * Globals.Time));
        }
    }
}