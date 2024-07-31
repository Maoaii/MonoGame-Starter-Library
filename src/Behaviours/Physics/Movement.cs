using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using src.Entities;

namespace src.Behaviours.Physics {
    class Movement : EntityBehaviour
    {
        private Vector2 velocity;
        private float speed;

        public Movement(Entity parent, float speed)
        {
            this.parent = parent;
            this.velocity = Vector2.Zero;
            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            velocity = Vector2.Zero;
            ReadInput();
            Move(gameTime);
        }

        private void ReadInput() {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W)) {
                velocity.Y += -speed;
            }
            if (state.IsKeyDown(Keys.S)) {
                velocity.Y += speed;
            }
            if (state.IsKeyDown(Keys.A)) {
                velocity.X += -speed;
            }
            if (state.IsKeyDown(Keys.D)) {
                velocity.X += speed;
            }
        }

        private void Move(GameTime gameTime) {
            parent.Position += velocity;
        }
    }
}