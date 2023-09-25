using Godot;
using System;

public partial class State : Node
{
	[Signal] public delegate void StateTransitionedEventHandler();
	
	public virtual void Enter() {}
	public virtual void Exit() {}
	public virtual void Update(float _delta) {}
	public virtual void PhysicsUpdate(float _delta) {}
}
