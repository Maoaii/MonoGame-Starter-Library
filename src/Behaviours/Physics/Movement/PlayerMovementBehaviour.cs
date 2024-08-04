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

        private float timeToMaxSpeed;
        private float timeToStop;
        private float stopSpeed;

        private float acceleratingTime;
        private float deacceleratingTime;

        private float easeValue;

        public PlayerMovementBehaviour(Entity parent, float maxSpeed, float timeToMaxSpeed, float timeToStop)
        {

            this.parent = parent;
            this.maxSpeed = maxSpeed;
            this.timeToMaxSpeed = timeToMaxSpeed;
            this.timeToStop = timeToStop;

            velocity = Vector2.Zero;
            easeValue = 0f;
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
                easeValue = Easing.Quadratic.Out(acceleratingTime, 0, maxSpeed, timeToMaxSpeed);
                parent.Velocity = new Vector2(-easeValue, parent.Velocity.Y);
            }
            else if (state.IsKeyDown(Keys.D)) {
                deacceleratingTime = 0f;
                acceleratingTime += Globals.Time;
                easeValue = Easing.Quadratic.Out(acceleratingTime, 0, maxSpeed, timeToMaxSpeed);
                parent.Velocity = new Vector2(easeValue, parent.Velocity.Y);
            }
            else {
                acceleratingTime = 0f;

                if (parent.Velocity.X > 0) {
                    if (stopSpeed == 0f) stopSpeed = parent.Velocity.X;

                    deacceleratingTime += Globals.Time;
                    easeValue = Easing.Quadratic.Out(deacceleratingTime, 0, stopSpeed, timeToStop);
                    parent.Velocity = new Vector2(stopSpeed - easeValue, parent.Velocity.Y);
                    if (parent.Velocity.X < 0) {
                        parent.Velocity = new Vector2(0, parent.Velocity.Y);
                    }
                }
                else if(parent.Velocity.X < 0){
                    if (stopSpeed == 0f) stopSpeed = parent.Velocity.X;

                    deacceleratingTime += Globals.Time;
                    easeValue = Easing.Quadratic.Out(deacceleratingTime, 0, stopSpeed, timeToStop);
                    parent.Velocity = new Vector2(stopSpeed - easeValue, parent.Velocity.Y);
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
            parent.Velocity = new Vector2(MathHelper.Clamp(parent.Velocity.X, -maxSpeed, maxSpeed), parent.Velocity.Y);
        }
    }
}