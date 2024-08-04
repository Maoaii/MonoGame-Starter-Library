using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Entities;

namespace MonoGameLibrary.Behaviours
{
    interface IVisualBehaviour
    {
        public void Draw(SpriteBatch spriteBatch);
    }
}