using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FIrstGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D texture;
        Texture2D texture_M1;
        Texture2D texture_M2;
        // Main Ship
        Vector2 position = Vector2.Zero;
        float speed = 2f;
        //
        int frameWidth = 108;
        int frameHeight = 140;
        Point currentFrame = new Point(0,0);
        Point spriteSize = new Point(5,2);
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 400);
        }

        // Выполняет начальную инициализацию игры
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        // Загружает ресурсы игры
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("Image/MoveShip");
            
        }

        // Обновляет состояние игры, управляет ее логикой
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ++currentFrame.X;
            if (currentFrame.X >= spriteSize.X)
            {
                currentFrame.X = 0;
                ++currentFrame.Y;
                if (currentFrame.Y >= spriteSize.Y)
                    currentFrame.Y = 0;
            }
            //position.X += speed;
            //if (position.X > Window.ClientBounds.Width - texture.Width ||
            //    position.X < 0)
            //{
            //    speed *= -1;
            //}
            // End
            base.Update(gameTime);
        }

        // Выполняет отрисовку на экране
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                texture,
                position,
                new Rectangle (
                    currentFrame.X * frameWidth,
                    currentFrame.Y * frameHeight,
                    frameWidth,frameHeight
                ),
                Color.White,
                0,Vector2.Zero,
                1,SpriteEffects.None,
                0);
            _spriteBatch.End();

            // End
            base.Draw(gameTime);
        }
    }
}
