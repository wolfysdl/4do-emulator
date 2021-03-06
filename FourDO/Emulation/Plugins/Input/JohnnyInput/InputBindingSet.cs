using System;
using System.Collections.Generic;

namespace FourDO.Emulation.Plugins.Input.JohnnyInput
{
	[Serializable]
	public class InputBindingSet : IEnumerable<InputBinding>
	{
		protected Dictionary<InputButton, InputBinding> bindings = new Dictionary<InputButton, InputBinding>();

		public void SetBinding(InputButton button, InputTrigger trigger)
		{
			if (trigger != null)
				this.bindings[button] = new InputBinding(button, trigger);
			else if (this.bindings.ContainsKey(button))
				this.bindings.Remove(button);
		}

		public InputTrigger GetButtonTrigger(InputButton button)
		{
			if (this.bindings.ContainsKey(button))
				return this.bindings[button].Trigger;
			else
				return null;
		}

		public int Count
		{
			get
			{
				return this.bindings.Count;
			}
		}

		public void Clear()
		{
			this.bindings.Clear();
		}

		#region Serialization Functions
		
		public IEnumerator<InputBinding> GetEnumerator()
		{
			return this.bindings.Values.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.bindings.Values.GetEnumerator();
		}

		public void Add(InputBinding binding)
		{
			this.bindings[binding.Button] = binding;
		}

		#endregion // Serialization Functions
	}
}
