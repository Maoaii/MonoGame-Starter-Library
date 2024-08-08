using System;
using MonoGameLibrary.Behaviours.DataSchemas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Entities;
using MonoGameLibrary.Behaviours.Physics.JumpGravity;

namespace MonoGameLibrary.Behaviours.Physics
{
    class JumpBehaviour : EntityBehaviour, IPhysicalBehaviour, IJumpBehaviour
    {
        private JumpAndGravity jumpResource;
        private Keys jumpKey;

        private bool canJump = true;
        private bool variableJump = false;

        public JumpBehaviour(Entity parent, JumpAndGravity jumpResource, Keys jumpKey)
        {
            this.parent = parent;
            this.jumpResource = jumpResource;
            this.jumpKey = jumpKey;
        }
        
        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(jumpKey)) {
                Jump(parent);
            }
            if (state.IsKeyUp(jumpKey) && !variableJump) {
                VariableJump(parent);
            }
        }

        public float CalculateJumpForce(JumpAndGravity jumpResource) {
            return (float)(2 * jumpResource.JumpHeight / jumpResource.JumpTimeToPeak)*-1;
        }

        public void Jump(Entity entity) {
            if (!canJump) return;
            entity.Velocity = new Vector2(entity.Velocity.X, CalculateJumpForce(jumpResource));
            canJump = false;
        }

        public void VariableJump(Entity entity) {
            entity.Velocity = new Vector2(entity.Velocity.X, entity.Velocity.Y * 0.5f);
            variableJump = true;
        }

        public void ResetJump() {
            canJump = true;
            variableJump = false;
        }
    }
}