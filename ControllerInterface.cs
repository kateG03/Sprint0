using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Sprint0
{
    internal interface IController
    {
        /// <summary>
        /// Dictionary that holds the keys and their associated values for a mouse or keyboard.
        /// </summary>
        public Dictionary<object, Action> KeyValuePairs { get; set; }
        /// <summary>
        /// Updates the game window and checks if a mouse was clicked or if a key was pressed.
        /// </summary>
        /// <param name="time"></param>
        void Update(GameTime time);
        /// <summary>
        /// Adds a key to KeyValuePairs
        /// </summary>
        /// <param name="o"></param>
        /// <param name="a"></param>
        void Add(object o, Action a);
    }
}
