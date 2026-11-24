using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Versioning;

namespace Monogame_3___Animations
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle window;
        Texture2D tribbleBrownTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleOrangeTexture;
        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;
        Rectangle tribbleOrangeRect;
        Vector2 tribbleOrangeSpeed;
        Rectangle tribbleCreamRect;
        Vector2 tribbleCreamSpeed;
        Rectangle tribbleBrownRect;
        Vector2 tribbleBrownSpeed;
        SoundEffect tribbleCoo;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.PreferredBackBufferWidth = window.Width;
            this.Window.Title = "Amination";
            _graphics.ApplyChanges();
            tribbleGreySpeed = new Vector2(1, 1);
            tribbleGreyRect = new Rectangle(300, 10, 100, 100);
            tribbleOrangeSpeed = new Vector2(1, 1);
            tribbleOrangeRect = new Rectangle(300, 10, 100, 100);
            tribbleCreamSpeed = new Vector2(1, 1);
            tribbleCreamRect = new Rectangle(300, 10, 100, 100);
            tribbleBrownSpeed = new Vector2(1, 1);
            tribbleBrownRect = new Rectangle(300, 10, 100, 100);

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
            if (tribbleGreyRect.X >= window.Width - tribbleGreyRect.Width || tribbleGreyRect.X <= 0)
            {
                tribbleCoo.Play();
                tribbleGreySpeed.X *= -1;
                /*
                if (tribbleGreySpeed.X > 0)
                {
                    tribbleGreySpeed.X += 1;
                }
                else
                {
                    tribbleGreySpeed.X -= 1;
                }
                */
            }
            if (tribbleGreyRect.Y >= window.Height - tribbleGreyRect.Height || tribbleGreyRect.Y <= 0)
            {
                tribbleCoo.Play();
                tribbleGreySpeed.Y *= -1;
                /*
                if (tribbleGreySpeed.Y > 0)
                {
                    tribbleGreySpeed.Y += 1;
                }
                else
                {
                    tribbleGreySpeed.Y -= 1;
                }
                */
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
