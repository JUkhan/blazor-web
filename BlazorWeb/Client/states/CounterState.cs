
using System;
namespace BlazorWeb.Client.States
{
	public class CounterState
	{
		public int Count { get; private set; }

		public void Incremennt()
		{
			Count++;
		}
	}
}

