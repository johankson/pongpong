using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pongpong
{
    public class PongGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Bat leftBat;
        private Bat rightBat;
        private Ball ball;

        public PongGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            leftBat = new Bat(50);

            var x2 = _graphics.GraphicsDevice.Viewport.Width - 60;
            rightBat = new Bat(x2);

            ball = new Ball(_graphics.GraphicsDevice.Viewport);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            leftBat.LoadContent(Content);
            rightBat.LoadContent(Content);
            ball.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Add your update logic here
            var viewport = _graphics.GraphicsDevice.Viewport;
            
            // Move the bats :tats:
            if (state.IsKeyDown(Keys.W) && leftBat.GetBounds().Top > 0)
                leftBat.MoveUp();
               
            if (state.IsKeyDown(Keys.S) && leftBat.GetBounds().Bottom < viewport.Height)
                leftBat.MoveDown();
            
            if (state.IsKeyDown(Keys.Up) && rightBat.GetBounds().Top > 0)
                rightBat.MoveUp();
               
            if (state.IsKeyDown(Keys.Down) && rightBat.GetBounds().Bottom < viewport.Height)
                rightBat.MoveDown();
            
            ball.Update(gameTime, leftBat.GetBounds(), rightBat.GetBounds());
            
            // Check boundaries
           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            leftBat.Draw(_spriteBatch);
            rightBat.Draw(_spriteBatch);
            ball.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
