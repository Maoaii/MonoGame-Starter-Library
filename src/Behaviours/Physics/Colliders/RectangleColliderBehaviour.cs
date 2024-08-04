using Microsoft.Xna.Framework;
using MonoGameLibrary.Entities;

namespace MonoGameLibrary.Behaviours.Physics
{
    class RectangleColliderBehaviour : EntityBehaviour, IColliderBehaviour, IPhysicalBehaviour
    {
        private Vector2 position;
        private Rectangle hitbox;

        public Rectangle Hitbox { get { return hitbox; } }

        public RectangleColliderBehaviour(Entity parent, Vector2 position, int width, int height)
        {
            this.parent = parent;
            this.position = position;
            hitbox = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void Update(GameTime gameTime)
        {
            position = parent.Position;
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }

        public bool IsColliding(IColliderBehaviour other)
        {
            return hitbox.Intersects(other.Hitbox);
        }
    }
}