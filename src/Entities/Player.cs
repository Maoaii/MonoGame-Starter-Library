using src.Behaviours;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src.Behaviours.Physics;
using System;
using src.Behaviours.Visuals;

namespace src.Entities {
    public class Player : Entity {

        private static Vector2 GRAVITY = new Vector2(0, 10f);
        private static float MOVEMENT_SPEED = 5f;
        private static float JUMP_FORCE = 300f;

        private BehaviourManager behaviourManager;

        public Player(Texture2D sprite, Vector2 position) {
            this.sprite = sprite;
            this.position = position;
            behaviourManager = new BehaviourManager();

            // Add behaviours
            AddBaseBehaviours();
        }

        private void AddBaseBehaviours() {
            // Rectangle collider
            behaviourManager.AddBehaviour(new RectangleCollider(this, position, sprite.Width, sprite.Height));

            // Gravity
            behaviourManager.AddBehaviour(new Gravity(this, GRAVITY));

            // Movement
            behaviourManager.AddBehaviour(new Movement(this, MOVEMENT_SPEED));

            // Jumping
            behaviourManager.AddBehaviour(new JumpBehaviour(this, JUMP_FORCE, Keys.Space));

            // Sprite renderer
            behaviourManager.AddBehaviour(new AnimatedSpriteRenderer(this, sprite));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            behaviourManager.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;

            behaviourManager.Update(gameTime);
            
            position.X += velocity.X * deltaTime;
                
            if (position.Y > 480 - sprite.Height) {
                velocity.Y = 0;
                position.Y = 480 - sprite.Height;
            }
            else {
                position.Y += velocity.Y * deltaTime;
            }
        }
    }
}