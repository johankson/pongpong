using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace pongpong
{
    public class Bat
    {
        private Texture2D texture;
        private Vector2 position;
        private float speed = 4;

        public Bat(int x)
        {
            position = new Vector2(x, 100);
        }
        
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("square");
        }
// goes up when you press W/up
        public void MoveUp()
        {
            position += new Vector2(0, -speed);
        }
        // goes down when you press S/down
        public void MoveDown()
        {
            position += new Vector2(0, speed);
        }
        //gets the color and bounds for bats/ball
        public void Draw(SpriteBatch batch)
        {
            var dest = GetBounds();
            batch.Draw(texture, dest, Color.White);
        }
// makes the shape of the bat
        public Rectangle GetBounds()
        {
            var dest = new Rectangle((int)position.X, (int)position.Y, 10, 70);
            return dest;
        }
    } 
}