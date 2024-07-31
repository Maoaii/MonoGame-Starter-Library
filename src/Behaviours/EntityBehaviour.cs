using Microsoft.Xna.Framework;
using src.Entities;

namespace src.Behaviours
{
    public abstract class EntityBehaviour
    {
        protected Entity parent;

        public abstract void Update(GameTime gameTime);
    }
}