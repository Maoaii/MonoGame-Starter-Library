using src.Behaviours;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src.Behaviours.Physics;
using System;

namespace src.Entities {
    public class Player : Entity {

        private static Vector2 GRAVITY = new Vector2(0, 0.1f);
        private static float MOVEMENT_SPEED = 1f;

        private BehaviourManager behaviourManager;

        public Player(Texture2D sprite, Vector2 position) {
            this.sprite = sprite;
            this.position = position;
            this.velocity = Vector2.Zero;
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

            // TODO: Jumping

            // TODO: Sprite renderer
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            behaviourManager.Update(gameTime);
        }
    }
}