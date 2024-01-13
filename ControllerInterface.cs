using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Sprint0
{
    internal interface IController
    {
        public Dictionary<object, Action> KeyValuePairs { get; set; }
        public int LastFrame { get; set; }
        public int Wait { get; set; }
        void Update(GameTime time);
        void Add(object o, Action a);
    }
}
