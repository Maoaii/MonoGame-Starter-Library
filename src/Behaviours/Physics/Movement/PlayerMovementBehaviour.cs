using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Entities;
using MonoGameLibrary.Utilities;

namespace MonoGameLibrary.Behaviours.Physics.Movement {
    class PlayerMovementBehaviour : EntityBehaviour, IPhysicalBehaviour, IMovementBehaviour
    {
        private Vector2 velocity;
        private float maxSpeed;

        private float acceleration;
        private float friction;

        public PlayerMovementBehaviour(Entity parent, float maxSpeed)
        {
            this.parent = parent;
            this.velocity = Vector2.Zero;
            this.maxSpeed = maxSpeed;

            this.acceleration = 4f;
            this.friction = 3f;
        }

        public void Update(GameTime gameTime)
        {
            ReadInput();
            ClampVelocity();
        }

        public void ReadInput()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.A)) {
                parent.Velocity = new Vector2(parent.Velocity.X - maxSpeed * acceleration * Globals.Time, parent.Velocity.Y);
                Console.WriteLine("Moving left with velocity: " + parent.Velocity);
            }
            else if (state.IsKeyDown(Keys.D)) {
                parent.Velocity = new Vector2(parent.Velocity.X + maxSpeed * acceleration * Globals.Time, parent.Velocity.Y);
                Console.WriteLine("Moving right with velocity: " + parent.Velocity);
            }
            else {
                Console.WriteLine(velocity.X);
                if (parent.Velocity.X > 0) {
                    parent.Velocity = new Vector2(parent.Velocity.X - maxSpeed * friction * Globals.Time, parent.Velocity.Y);
                    Console.WriteLine("Friction applied to velocity: " + parent.Velocity);
                    if (parent.Velocity.X < 0) {
                        parent.Velocity = new Vector2(0, parent.Velocity.Y);
                    }
                }
                else if (parent.Velocity.X < 0) {
                    parent.Velocity = new Vector2(parent.Velocity.X + maxSpeed * friction * Globals.Time, parent.Velocity.Y);
                    Console.WriteLine("Friction applied to velocity: " + parent.Velocity);
                    if (parent.Velocity.X > 0)
                    {
                        parent.Velocity = new Vector2(0, parent.Velocity.Y); 
                    }
                    MathHelper.Lerp(parent.Velocity.X, 0, 0.1f);
                }
            }

            ClampVelocity();
        }

        private void ClampVelocity()
        {
            if (parent.Velocity.X > maxSpeed) {
                parent.Velocity = new Vector2(maxSpeed, parent.Velocity.Y);
                Console.WriteLine("Clamped velocity");
            }
            else if (parent.Velocity.X < -maxSpeed) {
                parent.Velocity = new Vector2(-maxSpeed, parent.Velocity.Y);
                Console.WriteLine("Clamped velocity");
            }
        }
    }
}