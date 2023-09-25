using Godot;
using System;

public partial class SpawnMarker : Node2D
{
	[Export] public string MarkerID;
	private Marker2D _marker;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_marker = GetNode<Marker2D>("Marker2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public Vector2 GetMarkerGlobalPosition()
	{
		return _marker.GlobalPosition;
	}
}
