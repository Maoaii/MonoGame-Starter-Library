using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using src.Entities;

namespace src.Behaviours.Physics
{
    class JumpBehaviour : EntityBehaviour, IPhysicalBehaviour
    {
        private float jumpForce;
        private Keys jumpKey;
        public JumpBehaviour(Entity parent, float jumpForce, Keys jumpKey)
        {
            this.parent = parent;
            this.jumpForce = jumpForce;
            this.jumpKey = jumpKey;
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(jumpKey)) {
                Jump();
            }
        }

        public void Jump() {
            parent.Velocity = new Vector2(parent.Velocity.X, -jumpForce);
        }

    }
}