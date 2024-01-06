using System;
using System.Collections.Generic;

public class StateMachine
{
	private BaseState StateCurrent { get; set; }

	private Dictionary<Type, BaseState> _states = new Dictionary<Type, BaseState>();
}
