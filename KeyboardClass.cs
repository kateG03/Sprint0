using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sprint0
{

    public class KeyboardKate : IController
    {
        //Dictionary that contains keys and their associated values
        public Dictionary<object, Action> KeyValuePairs { get; set; }
        //Last state of the keyboard
        public KeyboardState LastState { get; set; }

        //Constructor
        public KeyboardKate()

        {
            //Set LastState to the current state of the keyboard
            LastState = Keyboard.GetState();
            //Instantiate Dictionary
            KeyValuePairs = new Dictionary<object, Action>();
        }

        public void Update(GameTime time)
        {
            //Set CurrentState to the current state of the keyboard
            KeyboardState CurrentState = Keyboard.GetState();
            //Check each key in KeyValuePairs and see if it was pressed
            foreach (object o in KeyValuePairs.Keys)
            {
                Keys k = (Keys)o;
                if (LastState.IsKeyDown(k) && CurrentState.IsKeyUp(k))
                {
                    //Trigger event for the key
                    KeyValuePairs[k].Invoke();
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