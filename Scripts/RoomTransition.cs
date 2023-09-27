using Godot;
using System;

public partial class RoomTransition : Node2D
{
	[Export] private string pathToDestinationScene;
	[Export] private string destinationMarkerId;
	private Node stageNode;
	private SceneManager sceneManager;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sceneManager = GetNode<SceneManager>("/root/SceneManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _on_area_2d_area_entered(Area2D area)
	{
		// TRANSITION TO NEW ROOM
		sceneManager.GotoScene(pathToDestinationScene, destinationMarkerId);
	}
}
