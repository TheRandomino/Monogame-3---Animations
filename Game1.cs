using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.CompilerServices;

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
        Texture2D spaceBGTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;
        Rectangle tribbleOrangeRect;
        Vector2 tribbleOrangeSpeed;
        Rectangle tribbleCreamRect;
        Vector2 tribbleCreamSpeed;
        Rectangle tribbleBrownRect;
        Vector2 tribbleBrownSpeed;
        Rectangle spaceBGRect;
        SoundEffect tribbleCoo;
        bool prevTribbleTouch;
        bool tribbleTouch;
        int tribbleOrangeRandSize, tribbleBrownRandYPos, tribbleBrownRandXPos;
        Random generator = new Random();
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
            tribbleGreySpeed = new Vector2(10, 0);
            tribbleGreyRect = new Rectangle(300, 10, 100, 100);
            tribbleOrangeSpeed = new Vector2(0, -5);
            tribbleOrangeRect = new Rectangle(400, 250, 100, 100);
            tribbleCreamSpeed = new Vector2(1, 1);
            tribbleCreamRect = new Rectangle(0, 0, 100, 100);
            tribbleBrownSpeed = new Vector2(0, 0);
            tribbleBrownRect = new Rectangle(1, 1, 100, 100);
            spaceBGRect = new Rectangle(0, 0, 800, 600);

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
            spaceBGTexture = Content.Load<Texture2D>("space");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            prevTribbleTouch = tribbleTouch;

            tribbleBrownRandXPos = generator.Next(0, (window.Width - tribbleBrownRect.Width) + 1);
            tribbleBrownRandYPos = generator.Next(0, (window.Height - tribbleBrownRect.Height) + 1);
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            tribbleBrownRect.X = tribbleBrownRandXPos;
            tribbleBrownRect.Y = tribbleBrownRandYPos;

            if (tribbleGreyRect.X >= window.Width + tribbleGreyRect.Width)
            {
                tribbleCoo.Play();
                tribbleGreyRect.X = 0 - tribbleGreyRect.Width;
                tribbleGreyRect.Y = generator.Next(0, window.Height - tribbleGreyRect.Height);
            }
            if (tribbleCreamRect.X >= window.Width - tribbleCreamRect.Width || tribbleCreamRect.X <= 0)
            {
                tribbleCreamSpeed.X *= -1;
            }
            if (tribbleCreamRect.Y >= window.Height - tribbleCreamRect.Height || tribbleCreamRect.Y <= 0)
            {
                tribbleCreamSpeed.Y *= -1;
            }
            if (tribbleCreamRect.Intersects(tribbleGreyRect) != true)
            {
                tribbleTouch = false;
            }
            if (tribbleCreamRect.Intersects(tribbleGreyRect))
            {
                tribbleTouch = true;
            }
            if (tribbleTouch == true && prevTribbleTouch == false)
            {
                tribbleCoo.Play();
            }
            if (tribbleOrangeRect.Y <= 0 - tribbleOrangeRect.Height)
            {
                tribbleCoo.Play();
                tribbleOrangeRandSize = generator.Next(50, 201);
                tribbleOrangeRect.Height = tribbleOrangeRandSize;
                tribbleOrangeRect.Width = tribbleOrangeRandSize;
                tribbleOrangeRect.Y = window.Height + tribbleOrangeRect.Height;  
            }
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(spaceBGTexture, spaceBGRect, Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
