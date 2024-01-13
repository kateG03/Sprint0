using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sprint0
{

	public class KeyboardKate
	{
		public Dictionary<object, Action> KeyValuePairs {get;set;}
		public int LastFrame { get;set;}
		public int Wait { get;set;}
		public KeyboardState LastState { get;set;}
		public KeyboardKate()

		{
			LastState = Keyboard.GetState();
			KeyValuePairs = new Dictionary<object, Action>();
			LastFrame = 0;
			Wait = 100;
		}

		public void Update(GameTime time)
		{
				KeyboardState CurrentState = Keyboard.GetState();
				foreach (object o in KeyValuePairs.Keys)
				{
					Keys k = (Keys)o;
					if (LastState.IsKeyDown(k) && CurrentState.IsKeyUp(k))
					{
						KeyValuePairs[k].Invoke();
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