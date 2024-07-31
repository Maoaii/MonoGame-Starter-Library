using Microsoft.Xna.Framework;
using src.Entities;

namespace src.Behaviours.Physics
{
    class RectangleCollider : EntityBehaviour, IRectangleCollider
    {
        private Vector2 position;
        private Rectangle hitbox;

        public Rectangle Hitbox { get { return hitbox; } }

        public RectangleCollider(Entity parent, Vector2 position, int width, int height)
        {
            this.parent = parent;
            this.position = position;
            hitbox = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public override void Update(GameTime gameTime)
        {
            position = parent.Position;
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }

        public bool IsColliding(IRectangleCollider other)
        {
            return hitbox.Intersects(other.Hitbox);
        }
    }
}