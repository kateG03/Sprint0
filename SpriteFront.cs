using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    public class SpriteFontKate : ISprite
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
        public SpriteFont Font { get; set; }
        public bool Start { get; set; }
        
        //Constructor
        public SpriteFontKate(SpriteFont font, Rectangle rectangle, Vector2 position)
        {
            //Initialize values
            Font = font;
            Rectangle = rectangle;
            Position = position;
            LastFrame = 0;
            Wait = 500;
            CurrentFrame = 0;
        }
        public void Move()
        {
            //Blank, font does not move
        }
        public void Update(GameTime time)
        {
            //Blank, font does not update
        }
        public void Draw(SpriteBatch SpriteBatch)
        {
            //Draw message to screen
            SpriteBatch.DrawString(Font, "Credits:\nProgram Made By: Kate Goertz\nSprites from: \nhttps://www.mariouniverse.com/wp-content/img/sprites/snes/smw/enemies-dinosaur.png", Position, Color.White);
        }
    }
}