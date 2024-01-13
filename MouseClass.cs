using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sprint0
{

    public class MouseKate : IController
    {
        public Dictionary<object, Action> KeyValuePairs { get; set; }
        public int LastFrame { get; set; }
        public int Wait { get; set; }
        public MouseState LastState { get; set; }
        public MouseState CurrentState { get; set; }
        public MouseKate()

        {
            LastState = Mouse.GetState();
            KeyValuePairs = new Dictionary<object, Action>();
            LastFrame = 0;
            Wait = 100;
        }
        public void LeftClick()
        {
            Point location = CurrentState.Position;
            if (location.X < 400 &&  location.Y < 225)
            {
                KeyValuePairs["Quad1"].Invoke();
            }
            else if (location.X > 400 && location.Y < 225)
            {
                KeyValuePairs["Quad2"].Invoke();
            }
            else if (location.X < 400 && location.Y > 225)
            {
                KeyValuePairs["Quad3"].Invoke();
            }
            else 
            {
                KeyValuePairs["Quad4"].Invoke();
            }
        }
        public void Update(GameTime time)
        {
            CurrentState = Mouse.GetState();
            foreach (object o in KeyValuePairs.Keys)
            {
                if (LastState.LeftButton == ButtonState.Pressed && CurrentState.LeftButton == ButtonState.Released)
                {
                    LeftClick();
                }
                if(LastState.RightButton == ButtonState.Pressed && CurrentState.RightButton == ButtonState.Released)
                {
                    KeyValuePairs["Right-click"].Invoke();
                }
            }

            LastState = CurrentState;
        }
        public void Add(object o, Action a)
        {
            KeyValuePairs.Add(o, a);
        }
    }
}