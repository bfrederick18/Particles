using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        Vector2 centerScreen;

        BaseSprite middlePx;

        ParticleSystem partSys;
        ParticleSource partSource;

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
            centerScreen = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            middlePx = new BaseSprite(pixel, centerScreen, Color.Red, Vector2.One);

            partSys = new ParticleSystem();
            partSource = new ParticleSource(centerScreen, 3, 10);

            for (int i = 0; i < 300; i++)
            {
                partSource.Generate(pixel, rand.Next(50, 150));
            }
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

            partSys.Update(gameTime, GraphicsDevice.Viewport);
            partSource.Update(gameTime, GraphicsDevice.Viewport);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            partSys.Draw(spriteBatch);
            partSource.Draw(spriteBatch);

            middlePx.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
