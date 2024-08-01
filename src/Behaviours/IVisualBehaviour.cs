using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src.Entities;

namespace src.Behaviours
{
    interface IVisualBehaviour
    {
        public void Draw(SpriteBatch spriteBatch);
    }
}