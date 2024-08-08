using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Behaviours.DataSchemas;
using MonoGameLibrary.Entities;
using MonoGameLibrary.Utilities;

namespace MonoGameLibrary.Behaviours.Physics.Movement {
    class PlayerMovementBehaviour : EntityBehaviour, IPhysicalBehaviour, IMovementBehaviour
    {
        private MovementSchema movementStats;
        private float stopSpeed;

        private float acceleratingTime;
        private float deacceleratingTime;

        private float velocityEaseValue;

        public PlayerMovementBehaviour(Entity parent, MovementSchema movementStats)
        {
            this.parent = parent;
            this.movementStats = movementStats;

            velocityEaseValue = 0f;
            stopSpeed = 0f;
            acceleratingTime = 0f;
            deacceleratingTime = 0f;
        }

        public void Update(GameTime gameTime)
        {
            Move();
            ClampVelocity();
        }

        public void Move()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.A)) {
                deacceleratingTime = 0f;
                acceleratingTime += Globals.Time;
                velocityEaseValue = Easing.Quadratic.Out(acceleratingTime, 0, movementStats.MaxSpeed, movementStats.TimeToMaxSpeed);
                parent.Velocity = new Vector2(-velocityEaseValue, parent.Velocity.Y);
            }
            else if (state.IsKeyDown(Keys.D)) {
                deacceleratingTime = 0f;
                acceleratingTime += Globals.Time;
                velocityEaseValue = Easing.Quadratic.Out(acceleratingTime, 0, movementStats.MaxSpeed, movementStats.TimeToMaxSpeed);
                parent.Velocity = new Vector2(velocityEaseValue, parent.Velocity.Y);
            }
            else {
                acceleratingTime = 0f;

                if (parent.Velocity.X > 0) {
                    if (stopSpeed == 0f) stopSpeed = parent.Velocity.X;

                    deacceleratingTime += Globals.Time;
                    velocityEaseValue = Easing.Quadratic.Out(deacceleratingTime, 0, stopSpeed, movementStats.TimeToStop);
                    parent.Velocity = new Vector2(stopSpeed - velocityEaseValue, parent.Velocity.Y);
                    if (parent.Velocity.X < 0) {
                        parent.Velocity = new Vector2(0, parent.Velocity.Y);
                    }
                }
                else if(parent.Velocity.X < 0){
                    if (stopSpeed == 0f) stopSpeed = parent.Velocity.X;

                    deacceleratingTime += Globals.Time;
                    velocityEaseValue = Easing.Quadratic.Out(deacceleratingTime, 0, stopSpeed, movementStats.TimeToStop);
                    parent.Velocity = new Vector2(stopSpeed - velocityEaseValue, parent.Velocity.Y);
                    if (parent.Velocity.X > 0)
                    {   
                        parent.Velocity = new Vector2(0, parent.Velocity.Y); 
                    }
                }
                else {
                    stopSpeed = 0f;
                }
            }

            ClampVelocity();
        }

        private void ClampVelocity()
        {
            parent.Velocity = new Vector2(MathHelper.Clamp(parent.Velocity.X, -movementStats.MaxSpeed, movementStats.MaxSpeed), parent.Velocity.Y);
        }
    }
}