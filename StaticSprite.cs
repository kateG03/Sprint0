﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework.Content;
using System.ComponentModel.Design;

namespace Sprint0
{
    public class StaticSprite : ISprite
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
        public StaticSprite(Texture2D texture, Rectangle rectangle, Vector2 position)
        {
            //Initialize values
            Texture = texture;
            Rectangle = rectangle;
            Position = position;
            Start = false;
            LastFrame = 0;
            Wait = 500;
            CurrentFrame = 0;
        }
        public void Move()
        {
            //Static, does not move
        }
        public void Update(GameTime time)
        {
            //Static, does not update
        }
        public void Draw(SpriteBatch SpriteBatch)
        {
            //Initialize rectangles
            int width = Rectangle.Width;
            int height = Rectangle.Height;

            Rectangle SourceRectangle = Rectangle;
            Rectangle DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width * 3, height * 3);

            //Draw on screen
            if (Start) SpriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Color.White);
        }
    }
}