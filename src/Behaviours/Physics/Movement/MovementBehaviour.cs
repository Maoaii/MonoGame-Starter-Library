using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src.Entities;

namespace src.Behaviours.Physics.Movement {
    class MovementBehaviour : EntityBehaviour, IPhysicalBehaviour, IMovementBehaviour
    {
        private Vector2 velocity;
        private float speed;

        public MovementBehaviour(Entity parent, float speed)
        {
            this.parent = parent;
            this.velocity = Vector2.Zero;
            this.speed = speed;
        }

        public void Update(GameTime gameTime)
        {
            velocity = Vector2.Zero;
            ReadInput();
            Move();
        }

        public void ReadInput()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.A)) {
                velocity.X += -speed;
            }
            if (state.IsKeyDown(Keys.D)) {
                velocity.X += speed;
            }
        }

        public void Move()
        {
            parent.Velocity += new Vector2(velocity.X, 0);
        }
    }
}