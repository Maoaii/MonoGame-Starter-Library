using MonoGameLibrary.Behaviours;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Behaviours.Physics;
using MonoGameLibrary.Behaviours.Physics.Movement;
using MonoGameLibrary.Behaviours.Visuals;
using MonoGameLibrary.Behaviours.DataSchemas;
using MonoGameLibrary.Utilities;
using System;

namespace MonoGameLibrary.Entities {
    public class Player : Entity {

        private static float MOVEMENT_SPEED = 300f;

        private BehaviourManager behaviourManager;

        private JumpAndGravity JumpAndGravityResource;

        public Player(Texture2D sprite, Vector2 position) {
            this.sprite = sprite;
            this.position = position;
            behaviourManager = new BehaviourManager();
            JumpAndGravityResource = JSONLiser.Load<JumpAndGravity>("./Data/PlayerJumpAndGravityStats.json");

            // Add behaviours
            AddBaseBehaviours();
        }

        private void AddBaseBehaviours() {
            // Rectangle collider
            behaviourManager.AddBehaviour(new RectangleColliderBehaviour(this, position, sprite.Width, sprite.Height));

            // Gravity
            behaviourManager.AddBehaviour(new GravityBehaviour(this, JumpAndGravityResource));

            // Movement
            behaviourManager.AddBehaviour(new PlayerMovementBehaviour(this, MOVEMENT_SPEED, 0.3f, 0.2f));

            // Jumping
            behaviourManager.AddBehaviour(new JumpBehaviour(this, JumpAndGravityResource, Keys.Space));

            // Sprite renderer
            behaviourManager.AddBehaviour(new AnimatedSpriteBehaviour(this, sprite));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            behaviourManager.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            behaviourManager.Update(gameTime);
            
            position.X += velocity.X * Globals.Time;
                
            if (position.Y > 480 - sprite.Height) {
                velocity.Y = 0;
                position.Y = 480 - sprite.Height;
                
                EntityBehaviour jumpBehaviour = behaviourManager.GetBehaviour(typeof(JumpBehaviour).Name);
                if (jumpBehaviour != null) {
                    ((JumpBehaviour)jumpBehaviour).ResetJump();
                }
            }
            else {
                position.Y += velocity.Y * Globals.Time;
            }
        }
    }
}