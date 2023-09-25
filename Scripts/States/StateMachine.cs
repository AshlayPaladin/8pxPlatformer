using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{
	protected State _currentState;
	protected Dictionary<string,State> _states;
	
	[Export] public State CurrentState;
	public Dictionary<string,State> States = new Dictionary<string,State>();
	
	protected void AddState(string _stateName, State _state)
	{
		_states.Add(_stateName, _state);
	}
}
