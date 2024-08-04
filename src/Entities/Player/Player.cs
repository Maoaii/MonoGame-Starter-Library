using src.Behaviours;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src.Behaviours.Physics;
using src.Behaviours.Physics.Movement;
using src.Behaviours.Visuals;
using src.Behaviours.DataClasses;

namespace src.Entities {
    public class Player : Entity {

        private static float MOVEMENT_SPEED = 5f;

        private BehaviourManager behaviourManager;

        private JumpAndGravity JumpAndGravityResource = new()
        {
            JumpHeight = 100,
            JumpTimeToPeak = 0.3f,
            JumpTimeToDescent = 0.2f
        };

        public Player(Texture2D sprite, Vector2 position) {
            this.sprite = sprite;
            this.position = position;
            behaviourManager = new BehaviourManager();

            // Add behaviours
            AddBaseBehaviours();
        }

        private void AddBaseBehaviours() {
            // Rectangle collider
            behaviourManager.AddBehaviour(new RectangleColliderBehaviour(this, position, sprite.Width, sprite.Height));

            // Gravity
            behaviourManager.AddBehaviour(new GravityBehaviour(this, JumpAndGravityResource));

            // Movement
            behaviourManager.AddBehaviour(new MovementBehaviour(this, MOVEMENT_SPEED));

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