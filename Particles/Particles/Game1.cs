using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Particles.ParticleObjects;
using System;
using System.Net;

namespace Particles
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random rand = new Random();

        Texture2D pixel;
        Texture2D torchTexture;
        Vector2 centerScreen;

        BaseSprite middlePx;

        ParticleSource partSource;
        Torch torch;

        Tuple<Vector2, Vector2, Vector2> rgb;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 3000;
            graphics.PreferredBackBufferHeight = 1900;

            graphics.ApplyChanges();

            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = Content.Load<Texture2D>("Textures/white2By2");
            torchTexture = Content.Load<Texture2D>("Textures/torch22by48");
            centerScreen = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            rgb = new Tuple<Vector2, Vector2, Vector2>(new Vector2(100, 200), new Vector2(0, 120), new Vector2(0, 0));

            middlePx = new BaseSprite(pixel, centerScreen, Color.Green, Vector2.One);

            torch = new Torch(torchTexture, centerScreen, new Vector2(3f), 1.0f, Vector2.Zero, Vector2.Zero, 1f, pixel);
        }

        protected override void UnloadContent()
        {
            //Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            middlePx.Update(gameTime, GraphicsDevice.Viewport);

            torch.Update(gameTime, GraphicsDevice.Viewport);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            torch.Draw(spriteBatch);

            middlePx.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
