using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    public class AnimatedSpriteMoving : ISprite
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
        public AnimatedSpriteMoving(Texture2D texture, int rows, int columns, Rectangle rectangle, Vector2 position)
        {
            //Initialize values
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Rectangle = rectangle;
            Position = position;
            LastFrame = 0;
            Wait = 500;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
        }
        public void Move()
        {
            //Moves this sprite up and down
            Position = new Vector2(Position.X - 10, Position.Y);
            //Once the sprite is off-screen, start again
            if (Position.X < -50) Position = new Vector2( 850, Position.Y);
        }
        public void Update(GameTime time)
        {
            //Update the sprite's animation
            LastFrame += time.ElapsedGameTime.Milliseconds;
            if (LastFrame >= Wait)
            {
                LastFrame -= Wait;
                Move();
                CurrentFrame++;
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
            }
        }
        public void Draw(SpriteBatch SpriteBatch)
        {
            //Initialize rectangles
            int width = Rectangle.Width / Columns;
            int height = Rectangle.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            Rectangle SourceRectangle = new Rectangle((width * column) + Rectangle.X, (height * row) + Rectangle.Y, width, height) ;
            Rectangle DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width*3, height*3);

            //Draw on screen
            if (Start) SpriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Color.White);
        }
    }
}