using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    public class StaticSpriteMoving : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int CurrentFrame { get; set; }
        public int TotalFrames { get; set; }
        public Rectangle Rectangle { get; set; }
        public int LastFrame { get; set; }
        public int Wait { get; set; }
        public Vector2 Position { get; set; }
        public bool Start { get; set; }

        //Constructor
        public StaticSpriteMoving(Texture2D texture, Rectangle rectangle, Vector2 position)
        {
            //Initialize values
            Texture = texture;
            Rectangle = rectangle;
            Position = position;
            LastFrame = 0;
            Wait = 500;
            CurrentFrame = 0;
        }
        public void Move()
        {
            //Moves this sprite left and right
            Position = new Vector2(Position.X, Position.Y - 10);
            //Once the sprite is off-screen, start again
            if (Position.Y < -20) Position = new Vector2( Position.X, 500);
        }
        public void Update(GameTime time)
        {
            //Update the sprite's animation
            LastFrame += time.ElapsedGameTime.Milliseconds;
            if (LastFrame >= Wait)
            {
                LastFrame -= Wait;
                Move();
            }
        }
        public void Draw(SpriteBatch SpriteBatch)
        {
            //Initialize rectangles
            int width = Rectangle.Width;
            int height = Rectangle.Height;

            Rectangle SourceRectangle = new Rectangle(width + Rectangle.X, height + Rectangle.Y, width, height) ;
            Rectangle DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width*3, height*3);

            //Draw on screen
            if (Start) SpriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Color.White);
        }
    }
}