using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.Utilities
{
    public static class Globals
    {   
        public static float Time { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static GraphicsDeviceManager Graphics { get; set; }

        public static void Update(GameTime gameTime) {
            Time = (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
        }
    }
}