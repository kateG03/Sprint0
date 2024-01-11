using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    internal interface ISprite
    {
        Texture2D Texture { get; set; }
        int Rows { get; set; }
        int Columns { get; set; }
        int CurrentFrame { get; set; }
        int TotalFrames { get; set; }
        Rectangle Rectangle { get; set; }
        int LastFrame { get; set; }
        int Wait {  get; set; }
        Vector2 Position { get; set; }

        void Move();
        void Update(GameTime time);
        void Draw(SpriteBatch SpriteBatch);
    }
}
