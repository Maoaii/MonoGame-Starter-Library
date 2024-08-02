using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src.Entities;


namespace src.Behaviours.Visuals {
    public class AnimatedSpriteBehaviour : EntityBehaviour, IVisualBehaviour
    {
        private Texture2D sprite;

        public AnimatedSpriteBehaviour(Entity parent, Texture2D sprite)
        {
            this.parent = parent;
            this.sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, parent.Position, Color.White);
        }
    }
}