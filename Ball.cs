using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace pongpong
{
    public class Ball
    {
        private readonly Viewport viewport;
        private Texture2D texture;
        private Vector2 position;
        private float speed = 4;
        private Vector2 momentum = Vector2.Zero;
// placing the ball in the center and going up left
        public Ball(Viewport viewport)
        {
            this.viewport = viewport;
            var centerX = viewport.Width / 2;
            var centerY = viewport.Height / 2;

            var bounds = GetBounds();
            
            position = new Vector2(centerX -bounds.Width/2, centerY-bounds.Height/2);
            momentum = new Vector2(-1, -1);
        }
      // getting the texture for ball  
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("square");
        }      
        // drawing texture for the ball
        public void Draw(SpriteBatch batch)
        {
            var dest = GetBounds();
            batch.Draw(texture, dest, Color.White);
        }
// making the bounds of bats
        public void Update(GameTime gameTime, Rectangle leftBounds, Rectangle rightBounds)
        {
            position += momentum * speed;

            var bounds = GetBounds();

            // Check bounds for entire area
            if (position.Y < 0 || bounds.Bottom>viewport.Height)
                momentum = new Vector2(momentum.X, -momentum.Y);
            
            if (position.X<0 || bounds.Right>viewport.Width)
                 momentum = new Vector2(-momentum.X, momentum.Y);
            
            // check bounds for bats
            if (GetBounds().Intersects(leftBounds) || GetBounds().Intersects(rightBounds))
                momentum = new Vector2(-momentum.X, momentum.Y);

            speed *= 1.001f;
        }        
        // check bouncing on floor and roof
        public Rectangle GetBounds()
        {
            var dest = new Rectangle((int)position.X, (int)position.Y, 10, 10);
            return dest;
        }
    }
}