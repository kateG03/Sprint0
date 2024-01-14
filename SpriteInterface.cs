using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    internal interface ISprite
    {
        /// <summary>
        /// Sprite texture.
        /// </summary>
        Texture2D Texture { get; set; }
        /// <summary>
        /// Rows of the game window, used to calculate movement.
        /// </summary>
        int Rows { get; set; }
        /// <summary>
        /// Columns of the game window, used to calculate movement.
        /// </summary>
        int Columns { get; set; }
        /// <summary>
        /// The current frame of the game window.
        /// </summary>
        int CurrentFrame { get; set; }
        /// <summary>
        /// The total frame of the game window, used to calculate movement.
        /// </summary>
        int TotalFrames { get; set; }
        /// <summary>
        /// Rectangle for sprite area.
        /// </summary>
        Rectangle Rectangle { get; set; }
        /// <summary>
        /// The previous frame of the game window.
        /// </summary>
        int LastFrame { get; set; }
        /// <summary>
        /// The wait time between animation.
        /// </summary>
        int Wait {  get; set; }
        /// <summary>
        /// Position of where the sprite should be drawn.
        /// </summary>
        Vector2 Position { get; set; }
        /// <summary>
        /// True if sprite is on screen, false otherwise.
        /// </summary>
        bool Start { get; set; }
        /// <summary>
        /// Moves the sprite across the game window.
        /// </summary>
        void Move();
        /// <summary>
        /// Updates the sprite on the game window if needed.
        /// </summary>
        /// <param name="time"></param>
        void Update(GameTime time);
        /// <summary>
        /// Draws the sprite on the game window.
        /// </summary>
        /// <param name="SpriteBatch"></param>
        void Draw(SpriteBatch SpriteBatch);
    }
}
