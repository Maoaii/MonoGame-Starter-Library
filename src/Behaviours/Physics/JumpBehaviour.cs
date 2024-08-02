using System;
using src.Behaviours.DataClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using src.Entities;

namespace src.Behaviours.Physics
{
    class JumpBehaviour : EntityBehaviour, IPhysicalBehaviour
    {
        private JumpAndGravity jumpResource;
        private Keys jumpKey;

        private float JumpForce => (float)(2 * jumpResource.JumpHeight / jumpResource.JumpTimeToPeak)*-1;

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
                Jump();
            }
            if (state.IsKeyUp(jumpKey) && !variableJump) {
                VariableJump();
            }
        }

        private void Jump() {
            if (!canJump) return;
            parent.Velocity = new Vector2(parent.Velocity.X, JumpForce);
            canJump = false;
        }

        private void VariableJump() {
            parent.Velocity = new Vector2(parent.Velocity.X, parent.Velocity.Y * 0.5f);
            variableJump = true;
        }

        public void ResetJump() {
            canJump = true;
            variableJump = false;
        }
    }
}