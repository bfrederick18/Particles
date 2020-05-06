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

        BaseSprite middlePx;
        AcceleratingSprite px;

        ParticleSystem partSys;

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
            middlePx = new BaseSprite(Content.Load<Texture2D>("Textures/white2By2"), new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.Red, Vector2.One);

            px = new AcceleratingSprite(Content.Load<Texture2D>("Textures/white2By2"), new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), new Vector2(100f, 100f), Vector2.Zero, new Vector2(0.1f, 0.1f));

            partSys = new ParticleSystem();

            for (int i = 0; i < 100; i++)
            {
                partSys.AddParticle(new Particle(Content.Load<Texture2D>("Textures/white2By2"), new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.Green, new Vector2(2f, 2f), new Vector2(rand.Next(-10, 10), rand.Next(-10, 10)), Vector2.Zero, 0.98f, rand.Next(50, 150)));
            }
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            middlePx.Update(gameTime, GraphicsDevice.Viewport);
            px.Update(gameTime, GraphicsDevice.Viewport);

            partSys.Update(gameTime, GraphicsDevice.Viewport);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            //px.Draw(spriteBatch);
            partSys.Draw(spriteBatch);

            middlePx.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
