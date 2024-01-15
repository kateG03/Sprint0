using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sprint0
{

    public class MouseController : IController
    {
        //Dictionary that contains keys and their associated values
        public Dictionary<object, Action> KeyValuePairs { get; set; }
        //Last state of the mouse
        public MouseState LastState { get; set; }
        //Current state of the mouse
        public MouseState CurrentState { get; set; }

        //Constructor
        public MouseController()

        {
            //Set LastState to the current state of the mouse
            LastState = Mouse.GetState();
            //Instantiate Dictionary
            KeyValuePairs = new Dictionary<object, Action>();
        }
        //This method locates which quadrant the mouse click was in the game window
        public void LeftClick()
        {
            //Find the current location
            Point location = CurrentState.Position;
            //Its in the first quadrant
            if (location.X < 400 &&  location.Y < 225)
            {
                KeyValuePairs["Quad1"].Invoke();
            }
            //Its in the second quadrant
            else if (location.X > 400 && location.Y < 225)
            {
                KeyValuePairs["Quad2"].Invoke();
            }
            //Its in the third quadrant
            else if (location.X < 400 && location.Y > 225)
            {
                KeyValuePairs["Quad3"].Invoke();
            }
            //Its in the fourth quadrant
            else 
            {
                KeyValuePairs["Quad4"].Invoke();
            }
        }
        public void Update(GameTime time)
        {
            //Set CurrentState to the current state of the mouse
            CurrentState = Mouse.GetState();
            //Check each key in KeyValuePairs and see if it was clicked
            foreach (object o in KeyValuePairs.Keys)
            {
                if (LastState.LeftButton == ButtonState.Pressed && CurrentState.LeftButton == ButtonState.Released)
                {
                    //Trigger left-click event
                    LeftClick();
                }
                if(LastState.RightButton == ButtonState.Pressed && CurrentState.RightButton == ButtonState.Released)
                {
                    //Trigger right-click event
                    KeyValuePairs["Right-click"].Invoke();
                }
            }
            //Set LastState to the CurrentState
            LastState = CurrentState;
        }
        public void Add(object o, Action a)
        {
            //Add key
            KeyValuePairs.Add(o, a);
        }
    }
}