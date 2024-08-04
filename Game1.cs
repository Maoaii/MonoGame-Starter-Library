using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Entities;
using MonoGameLibrary.Utilities;

namespace MonoGameLibrary;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player player;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 640;
        _graphics.PreferredBackBufferHeight = 480;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();
        base.Initialize();

        Globals.Content = Content;
        Globals.Graphics = _graphics;
        Globals.SpriteBatch = _spriteBatch;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        player = new Player(Content.Load<Texture2D>("Entities/rectangle_entity"), new Vector2(100, 100));
    }

    protected override void Update(GameTime gameTime)
    {
        Globals.Update(gameTime);
        
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
        player.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.AliceBlue);

        base.Draw(gameTime);
        DrawPlayer(_spriteBatch);
    }

    private void DrawPlayer(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Begin();
        player.Draw(_spriteBatch);
        _spriteBatch.End();
    }
}
